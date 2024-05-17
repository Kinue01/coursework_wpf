using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetIngredientByIdUseCase(IngredsRepository repository)
    {
        public async Task<Ingredient> Execute(int id)
        {
            return await repository.GetIngredientById(id);
        }
    }
}
