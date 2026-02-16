namespace Waker.Domain.Entities
{
    public class SoundEntity
    {
        public SoundEntity(string displayName, string fileName)
        {
            DisplayName = displayName;
            FileName = fileName;
        }

        public string DisplayName { get; set; }
        public string FileName { get; set; }
    }
}
