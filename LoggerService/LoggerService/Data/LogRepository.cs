using AutoMapper;
using LoggerService.Entities;
using LoggerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerService.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext Context;
        private readonly IMapper Mapper;

        public LogRepository(LogContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Log> GetLogList()
        {
            return Context.Log.ToList();
        }

        public Log GetLogById(Guid logId)
        {
            return Context.Log.FirstOrDefault(e => e.LogID == logId);
        }

        public LogConfirmationDto CreateLog(Log log)
        {
            log.LogID = Guid.NewGuid();

            Context.Log.Add(log);
            Context.SaveChanges();

            return Mapper.Map<LogConfirmationDto>(log);
        }
    }
}
