using IlluminareToys.Domain.UseCases;

namespace IlluminareToys.Application.Workers
{
    public class SyncProductsWorker //: BackgroundService
    {
        private readonly ISyncProductsUseCase _syncProductsUseCase;
        //private readonly TimeSpan _interval = TimeSpan.FromHours(3);
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);

        public SyncProductsWorker(ISyncProductsUseCase syncProductsUseCase)
        {
            _syncProductsUseCase = syncProductsUseCase;
        }

        //protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        //{
        //    //while (!cancellationToken.IsCancellationRequested)
        //    //{
        //    //    await _syncProductsUseCase.ExecuteAsync(cancellationToken);
        //    //    await Task.Delay(_interval, cancellationToken);
        //    //}
        //}
    }
}
