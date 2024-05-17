using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddIngredUseCase(IngredsRepository repository)
    {
        public async Task<bool> Execute(Ingredient ingredient)
        {
            return await repository.AddIngred(ingredient);
        }
    }
}
