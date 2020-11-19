using System.Collections.Generic;
using DeviceService.Models;

namespace DeviceService.Entities
{
    public interface IPostgresqlRepo
    {
        bool SaveChanges();

        IEnumerable<Log> GetAllLogs();
        Log GetLogById(int id);
        void CreateLog(Log log);
        void UpdateLog(Log log);
        void DeleteLog(Log log);
    }
}