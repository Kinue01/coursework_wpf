using coursework.Domain.Model;

namespace coursework.Data.Repository
{
    public interface PositionDbRepository
    {
        IAsyncEnumerable<Position> GetPositions();
        Task<Position> GetPositionById(int positionId);
    }
}
