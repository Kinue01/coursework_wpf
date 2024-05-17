using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredsOnWarehouseUseCase(IngredientOnWarehouseRepository repository)
    {
        public IAsyncEnumerable<IngredientOnWarehouse> Execute()
        {
            return repository.GetIngredientOnWarehouse();
        }
    }
}
