using Waker.Domain.Entities;

namespace Waker.Domain.Repositories
{
    public interface ISoundRepository
    {
        public SoundEntity[] GetEntities();
    }
}
