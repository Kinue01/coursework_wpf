using coursework.Data.Repository;
using coursework.Domain.Model;
using coursework.Domain.Repository;

namespace coursework.Data.RepositoryImpl
{
    public class PositionRepositoryImpl(PositionDbRepository repository) : PositionRepository
    {
        public async Task<Position> GetPositionById(int positionId)
        {
            return await repository.GetPositionById(positionId);
        }

        public IAsyncEnumerable<Position> GetPositions()
        {
            return repository.GetPositions();
        }
    }
}
