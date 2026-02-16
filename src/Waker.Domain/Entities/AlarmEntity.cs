namespace Waker.Domain.Entities
{
    public class AlarmEntity
    {
        public AlarmEntity(DateTime dateTime, SoundEntity sound)
        {
            DateTime = dateTime;
            Sound = sound;
        }

        public AlarmEntity(int id, DateTime dateTime, SoundEntity sound)
        {
            Id = id;
            DateTime = dateTime;
            Sound = sound;
        }

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public SoundEntity Sound { get; set; }
    }
}
