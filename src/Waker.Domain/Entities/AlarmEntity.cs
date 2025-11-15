namespace Waker.Domain.Entities
{
    public class AlarmEntity
    {
        public AlarmEntity(DateTime dateTime, SoundEntity sound)
        {
            DateTime = dateTime;
            Sound = sound;
        }

        public DateTime DateTime { get; set; }
        public SoundEntity Sound { get; set; }
    }
}
