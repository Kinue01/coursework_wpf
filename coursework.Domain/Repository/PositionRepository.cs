using coursework.Domain.Model;

namespace coursework.Domain.Repository
{
    public interface PositionRepository
    {
        IAsyncEnumerable<Position> GetPositions();
        Task<Position> GetPositionById(int positionId);
    }
}
