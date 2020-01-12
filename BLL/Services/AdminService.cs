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
using Mapper = BLL.Infrastructure.Mapper;

namespace BLL.Services
{
    public class AdminService: IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateCategory(CategoryDTO category)
        {
            var categoryToCreate = Mapper.FromCategoryDTOToCategory(category);
            await unitOfWork.Categories.Create(categoryToCreate);
            await unitOfWork.SaveChanges();
        }
    }
}
