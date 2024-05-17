using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class UpdateIngredUseCase(IngredsRepository repository)
    {
        public async Task<bool> Execute(Ingredient ingredient)
        {
            return await repository.UpdateIngred(ingredient);
        }
    }
}
