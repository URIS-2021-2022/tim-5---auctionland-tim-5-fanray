using LoggerService.Entities;
using LoggerService.Models;
using System;
using System.Collections.Generic;

namespace LoggerService.Data
{
    public interface ILogRepository
    {
        List<Log> GetLogList();
        Log GetLogById(Guid logId);
        LogConfirmationDto CreateLog(Log log);
    }
}
