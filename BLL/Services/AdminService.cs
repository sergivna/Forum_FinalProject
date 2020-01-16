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
    public class AdminService: IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = MappingConfiguration.ConfigureMapper().CreateMapper();
        }

        public async Task CreateCategory(CategoryDTO category)
        {
            var categoryToCreate = mapper.Map<Category>(category);
            await unitOfWork.Categories.Create(categoryToCreate);
            await unitOfWork.SaveChanges();
        }
    }
}
