namespace iStore.Models;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}