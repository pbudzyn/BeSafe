namespace PlaceNetwork.BusinessLogic.Repositories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork(); 
    }
}