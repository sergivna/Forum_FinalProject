﻿using AutoMapper;
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
        public AdditionalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var contries = await unitOfWork.Additional.GetCountries();
            var result =  CustomMapperBLL.FromCountryToCountryDTO(contries);
            return result;
        }
    }
}
