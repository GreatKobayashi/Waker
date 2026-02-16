using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Aplication.Controllers
{
    public class SoundController
    {
        private ISoundRepository _soundRepository;

        public SoundController(ISoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public SoundEntity[] GetEntities()
        {
            return _soundRepository.GetEntities();
        }
    }
}
