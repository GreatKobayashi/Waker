using Waker.Aplication.Controllers;
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
            _soundRepository = new SoundAndroid();
        }

        public static AlarmController GetAlarmController()
        {
            return new(new AlarmAndroid(), new AlarmSQLite(FileSystem.AppDataDirectory), _soundRepository);
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
