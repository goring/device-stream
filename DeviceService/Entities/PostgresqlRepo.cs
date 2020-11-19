using System;
using System.Collections.Generic;
using System.Linq;
using DeviceService.Models;
using DeviceService.Entities;

namespace DeviceService.Entities
{
    public class PostgresqlRepo : IPostgresqlRepo
    {
        private readonly DeviceDBContext _context;

        public PostgresqlRepo(DeviceDBContext context)
        {
            _context = context;
        }

        public void CreateLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            _context.Logs.Add(log);
        }

        public void DeleteLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            _context.Logs.Remove(log);
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _context.Logs.ToList();
        }

        public Log GetLogById(int id)
        {
            return _context.Logs.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLog(Log log)
        {
            throw new NotImplementedException();
        }
    }
}