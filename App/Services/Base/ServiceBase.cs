using App.Data;
using AutoMapper;
using RiotSharp.Interfaces;

namespace App.Services.Base
{
    public class ServiceBase
    {
        public IRiotApi Api { get; set; }

        public IMapper Mapper { get; set; }

        public IDbContext Db { get; set; }

        public ServiceBase(IRiotApi api, IMapper mapper, IDbContext db)
        {
            Api = api;
            Mapper = mapper;
            Db = db;
        }
    }
}