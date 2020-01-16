using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdditionalService : IAdditionalService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AdditionalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
        }
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var contries = await unitOfWork.Additional.GetCountries();
            return mapper.Map<IEnumerable<CountryDTO>>(contries);
        }
    }
}
