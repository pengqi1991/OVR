using AutoMapper;
using OVR.Common.IDCode.Snowflake;
using OVR.DbContexts;
using OVR.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Services
{
    public interface IBaseService
    {
    }
    public class BaseService : IBaseService
    {
        public readonly IUnitOfWork<MSDbContext> _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IdWorker _idWorker;

        public BaseService(IUnitOfWork<MSDbContext> unitOfWork, IMapper mapper, IdWorker idWorker)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idWorker = idWorker;
        }
    }
}
