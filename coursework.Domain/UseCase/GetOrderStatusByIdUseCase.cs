using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetOrderStatusByIdUseCase(StatusRepository repository)
    {
        public async Task<Status> Execute(int id)
        {
            return await repository.GetStatusById(id);
        }
    }
}
