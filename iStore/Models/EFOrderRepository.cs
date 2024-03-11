using Microsoft.EntityFrameworkCore;

namespace iStore.Models;

public class EFOrderRepository : IOrderRepository
{
    private readonly StoreDbContext _context;

    public EFOrderRepository(StoreDbContext context)
    {
        _context = context;
    }

    public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Product);

    public void SaveOrder(Order order)
    {
        _context.AttachRange(order.Lines.Select(l => l.Product));
        if (order.OrderID == 0)
        {
            _context.Orders.Add(order);
        }
        _context.SaveChanges();
    }
}