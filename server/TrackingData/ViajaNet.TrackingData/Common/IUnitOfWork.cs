namespace ViajaNet.TrackingData.Common
{
    public interface IUnitOfWork<TContext>
    {
        int Commit();
    }
}
