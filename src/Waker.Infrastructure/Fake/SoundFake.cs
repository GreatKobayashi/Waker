using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Infrastructure.Fake
{
    public class SoundFake : ISoundRepository
    {
        public SoundEntity[] GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
