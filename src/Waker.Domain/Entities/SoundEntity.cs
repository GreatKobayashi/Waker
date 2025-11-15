namespace Waker.Domain.Entities
{
    public class SoundEntity
    {
        public SoundEntity(string fileName, string displayName)
        {
            FileName = fileName;
            DisplayName = displayName;
        }

        public string FileName { get; set; }
        public string DisplayName { get; set; }
    }
}
