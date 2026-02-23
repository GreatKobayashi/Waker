using Waker.Aplication.Controllers;
using Waker.Domain;
using Waker.Domain.Repositories;
using Waker.Infrastructure.Fake;
using Waker.Infrastructure.SQLite;
using Waker.Root.Platforms.Android.Sound;

namespace Waker.Root
{
    public static class Factories
    {
        private readonly static ISoundRepository _soundRepository;

#if __ANDROID__
        static Factories()
        {
            if (Shared.IsFake)
            {
                _soundRepository = new SoundFake();
            }
            else
            {
                _soundRepository = new SoundAndroid();
            }
        }

        public static AlarmController GetAlarmController()
        {
            if (Shared.IsFake)
            {
                return new(new AlarmFake(), new AlarmFake(), _soundRepository);
            }
            else
            {
                return new(new AlarmAndroid(), new AlarmSQLite(FileSystem.AppDataDirectory), _soundRepository);
            }
        }

        public static SoundController GetSoundController()
        {
            return new(_soundRepository);
        }
#endif

#if __IOS__
        static Factories()
        {
            // TODO
        }

        public static AlarmController GetAlarmController()
        {
            // TODO
            return new(alarmSet, new AlarmSQLite(FileSystem.AppDataDirectory), _soundRepository);
        }

        public static SoundController GetSoundController()
        {
            // TODO
        }
#endif
    }

}
