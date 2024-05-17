using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetWorkshopByIdUseCase(WorkshopRepository repository)
    {
        public async Task<Workshop> Execute(int id)
        {
            return await repository.GetWorkshopById(id);
        }
    }
}
