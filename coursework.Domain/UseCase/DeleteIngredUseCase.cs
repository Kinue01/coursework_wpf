using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class DeleteIngredUseCase(IngredsRepository repository)
    {
        public async Task<bool> Execute(int id)
        {
            return await repository.DeleteIngred(id);
        }
    }
}
