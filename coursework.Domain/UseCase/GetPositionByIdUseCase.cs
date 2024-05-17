using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetPositionByIdUseCase(PositionRepository repository)
    {
        public async Task<Position> Execute(int id)
        {
            return await repository.GetPositionById(id);
        }
    }
}
