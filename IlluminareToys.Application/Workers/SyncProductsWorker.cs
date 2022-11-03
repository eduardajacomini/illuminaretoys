using AutoMapper;
using IlluminareToys.Domain.Entities;
using IlluminareToys.Infrastructure.Bling;
using IlluminareToys.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IlluminareToys.Application.Workers
{
    public class SyncProductsWorker : BackgroundService
    {
        private readonly IBlingClient _blingClient;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SyncProductsWorker(IBlingClient blingClient,
                                  IMapper mapper,
                                  IConfiguration configuration)
        {
            _blingClient = blingClient;
            _mapper = mapper;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = await _blingClient.GetProductsAsync();

                    var resultItems = result.Response.Products.Select(x => x.Product);

                    var entities = _mapper.Map<IEnumerable<Product>>(resultItems);

                    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

                    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));

                    using var context = new AppDbContext(optionsBuilder.Options);

                    await context.Products.AddRangeAsync(entities);

                    await context.SaveChangesAsync();

                    await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
