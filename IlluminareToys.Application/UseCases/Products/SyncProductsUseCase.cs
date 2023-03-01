using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Domain.UseCases;
using IlluminareToys.Infrastructure.Bling;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IlluminareToys.Application.UseCases.Products
{
    public class SyncProductsUseCase : ISyncProductsUseCase
    {
        private readonly IBlingClient _blingClient;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SyncProductsUseCase(IBlingClient blingClient, IMapper mapper, IConfiguration configuration)
        {
            _blingClient = blingClient;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));

            using var context = new AppDbContext(optionsBuilder.Options);
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var result = await _blingClient.GetProductsAsync(cancellationToken);

                var resultItems = result.Response.Products.Select(x => x.Product);
                var resultItemsIds = resultItems.Select(x => x.BlingId);

                var entities = _mapper.Map<IEnumerable<Product>>(resultItems).ToList();

                var productsInDb = await context
                                            .Products
                                            .Where(x => resultItemsIds.Contains(x.BlingId))
                                            .ToListAsync(cancellationToken);

                if (productsInDb.Any())
                {
                    foreach (var product in productsInDb)
                    {
                        var item = entities.FirstOrDefault(x => x.BlingId == product.BlingId);

                        if (item is not null)
                        {
                            product.SetBlingCreatedAt(item.BlingCreatedAt);
                            product.SetBlingUpdatedAt(item.BlingUpdatedAt);
                            product.SetState(item.State);
                            product.SetCategoryDescription(item.CategoryDescription);
                            product.SetCategoryId(item.CategoryId);
                            product.SetCode(item.Code);
                            product.SetDescription(item.Description);
                            product.SetBrand(item.Brand);
                            //Comentado pois a imagem agora será cadastrada direto na aplicação.
                            //product.SetImageUrl(item.ImageUrl);
                            product.SetUnity(item.Unity);
                            product.SetPrice(item.Price);
                            product.SetPriceCost(item.PriceCost);
                            product.SetCurrentStock(item.CurrentStock);

                            entities.Remove(item);
                        }
                    }
                }

                await context.Products.AddRangeAsync(entities, cancellationToken);

                await DeleteProductsThatNotInBling(context, resultItemsIds, cancellationToken);

                await context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                if (ex.InnerException.Message.Contains("unique"))
                {
                    return;
                }

                throw ex;
            }
        }

        private async Task DeleteProductsThatNotInBling(AppDbContext context,
                                                        IEnumerable<string> resultItemsIds,
                                                        CancellationToken cancellationToken)
        {
            var productsInDbToDelete = await context
                                                .Products
                                                .Where(x => !resultItemsIds.Contains(x.BlingId))
                                                .ToListAsync(cancellationToken);

            var productsIds = productsInDbToDelete.Select(x => x.Id);

            var tagsProductsToDelete = await context
                                                .TagsProducts
                                                .Where(x => productsIds.Contains(x.ProductId))
                                                .ToListAsync(cancellationToken);

            var productsGroupsToDelete = await context
                                                .ProductsGroups
                                                .Where(x => productsIds.Contains(x.ProductId))
                                                .ToListAsync(cancellationToken);
            var productsGroupsIds = productsGroupsToDelete.Select(x => x.Id);

            var productsGroupsAgesToDelete = await context
                                                    .ProductsGroupsAges
                                                    .Where(x => productsGroupsIds.Contains(x.ProductGroupId))
                                                    .ToListAsync(cancellationToken);

            var productsAgesToDelete = await context
                                                .ProductsAges
                                                .Where(x => productsIds.Contains(x.ProductId))
                                                .ToListAsync(cancellationToken);


            context.TagsProducts.RemoveRange(tagsProductsToDelete);
            context.Products.RemoveRange(productsInDbToDelete);
            context.ProductsGroupsAges.RemoveRange(productsGroupsAgesToDelete);
            context.ProductsGroups.RemoveRange(productsGroupsToDelete);
            context.ProductsAges.RemoveRange(productsAgesToDelete);
        }
    }
}
