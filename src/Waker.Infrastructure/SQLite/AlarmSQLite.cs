using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Waker.Domain;
using Waker.Domain.Entities;
using Waker.Domain.Repositories;

namespace Waker.Infrastructure.SQLite
{
    public class AlarmSQLite : IAlarmRepository
    {
        private readonly AlarmContext _db;
        private readonly static string _dbName = "app.db";

        public AlarmSQLite(string dbDirectoryPath)
        {
            var path = Path.Combine(dbDirectoryPath, _dbName);

            if (Shared.ResetDbOnStartUp && File.Exists(path))
            {
                File.Delete(path);
            }

            var options = new DbContextOptionsBuilder<AlarmContext>().UseSqlite($"Filename={path}").Options;
            _db = new AlarmContext(options);

            _db.Database.EnsureCreated();
        }

        public AlarmEntity[] GetAllEntities()
        {
            return _db.Alarms.ToList().Select(Parse).ToArray();
        }

        public AlarmEntity[] GetEntities(DateTime? from, DateTime? to)
        {
            var query = _db.Alarms.AsQueryable();

            if (from is not null)
            {
                var fromValue = from.Value;
                query = query.Where(x => x.DateTime >= from);
            }

            if (to is not null)
            {
                var toValue = to.Value;
                query = query.Where(x => x.DateTime <= to);
            }

            return query.Select(Parse).ToArray();
        }

        public void Set(AlarmEntity alarm)
        {
            var record = new AlarmRecord
            {
                DateTime = alarm.DateTime,
                SoundFileName = alarm.Sound.FileName
            };
            _db.Alarms.Add(record);
            _db.SaveChanges();

            alarm.Id = record.Id;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Cancel(AlarmEntity alarm)
        {
            var record = _db.Alarms.Find(alarm.Id);
            if (record is not null)
            {
                _db.Alarms.Remove(record);
            }

            _db.SaveChanges();
        }

        private AlarmEntity Parse(AlarmRecord record)
        {
            return new AlarmEntity(record.Id, record.DateTime, new SoundEntity("", record.SoundFileName));
        }
    }

    public class AlarmContext : DbContext
    {
        public DbSet<AlarmRecord> Alarms => Set<AlarmRecord>();

        public AlarmContext(DbContextOptions<AlarmContext> options)
            : base(options)
        {
        }
    }

    [Table("Alarms")]
    public class AlarmRecord
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public string SoundFileName { get; set; } = "";
    }
}
