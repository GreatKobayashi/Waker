using System.Text.Json;
using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Root.Platforms.Android.Sound
{
    public class SoundAndroid : ISoundRepository
    {
        private static readonly string _fileName = "SoundList.json";

        public async Task<SoundEntity[]> GetEntities()
        {
            try
            {
                using var stream = await FileSystem.Current.OpenAppPackageFileAsync(_fileName);
                using var reader = new StreamReader(stream);
                var dic = JsonSerializer.Deserialize<Dictionary<string, string>>(await reader.ReadToEndAsync())!;

                var entities = new List<SoundEntity>();
                foreach (var pair in dic)
                {
                    entities.Add(new SoundEntity(pair.Key, pair.Value));
                }

                return entities.ToArray();
            }
            catch
            {
                throw;
            }
        }
    }
}
