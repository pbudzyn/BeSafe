namespace PlaceNetwork.BusinessLogic.Repositories
{
    public class UnitOfWorkFactory: IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}