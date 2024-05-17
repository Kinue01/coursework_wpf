using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class AddWorkshopUseCase(WorkshopRepository repository)
    {
        public async Task<bool> Execute(Workshop workshop)
        {
            return await repository.AddWorkshop(workshop);
        }
    }
}
