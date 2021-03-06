﻿using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await unitOfWork.Categories.GetAll();
            return mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            var category =  await unitOfWork.Categories.GetById(id);
            if (category == null)
                throw new NullReferenceException("category is null");
            return mapper.Map<CategoryDTO>(category);
        }
    }
}
