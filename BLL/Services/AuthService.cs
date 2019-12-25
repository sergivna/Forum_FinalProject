using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public string GetToken(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO LogIn(UserLoginDTO userLogin)
        {
            throw new NotImplementedException();
        }

        public UserDTO Register(UserRegisterDTO userRegister)
        {
            throw new NotImplementedException();
        }
    }
}
