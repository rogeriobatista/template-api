namespace NostraHC.Infra.Data.UnityOfWork
{
    public interface IUnityOfWork
    {
        Task SaveChanges();
    }
}
