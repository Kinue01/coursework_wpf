using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Domain.UseCase
{
    public class GetPositionsUseCase(PositionRepository repository)
    {
        public IAsyncEnumerable<Position> Execute()
        {
            return repository.GetPositions();
        }
    }
}
