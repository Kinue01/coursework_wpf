using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredTypeByIdUseCase(TypeRepository repository)
    {
        public async Task<IngredType> Execute(int id)
        {
            return await repository.GetTypeById(id);
        }
    }
}
