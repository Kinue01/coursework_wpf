using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddOrderUseCase(OrderRepository repository)
    {
        public async Task<bool> Execute(int cId, string addr, int cost, int pCount, DateOnly date, int pId, List<Product> products)
        {
            return await repository.AddOrder(cId, addr, cost, pCount, date, pId, products);
        }
    }
}
