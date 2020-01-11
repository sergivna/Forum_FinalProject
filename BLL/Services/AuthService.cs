using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public readonly IConfiguration configuration;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<String> GetToken(UserDTO userDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, userDTO.UserName)
            };
            var appuser = CustomMapperBLL._fromClientProfileToUserDTO.CreateMapper().Map<UserDTO, ApplicationUser>(userDTO);
            var roles = await userManager.GetRolesAsync(appuser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Token:Key").Value));
                var singin = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "issuer",
                Audience = "audience",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = singin
            };

            //var token = new JwtSecurityToken(
            //        issuer: "issuer",
            //        audience: "audience",
            //        expires: DateTime.Now.AddHours(1),
            //        signingCredentials: singin
            //    );

                 var handler = new JwtSecurityTokenHandler();
                 var token = handler.CreateToken(tokenDescriptor);
                return handler.WriteToken(token);
            
        }

        public async Task<UserDTO> LogIn(UserLoginDTO userLogin)
        {
            var user = await userManager.FindByEmailAsync(userLogin.Email);
            if (user == null)
                return null;
            var result = await signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);           
            if (result.Succeeded)
            {
                var roles = await unitOfWork.Roles.GetAll();
                //List<RoleDTO> roleDTOs = new List<RoleDTO>();
                //var roles = await Task.WhenAll(roles.Where())
                List<string> result1 = roles.Where(a => user.ApplicationUserRoles.Any(b => a.Id == b.RoleId)).Select(rol => rol.Name).ToList();
                //foreach(var item in roles)
                //{
                //    if (user.ApplicationUserRoles.Any(r => r.RoleId == item.Id))
                //        roleDTOs.Add(CustomMapperBLL.FromRoleToRoleDTO(item));

                //}              
                var profile =  await unitOfWork.UserProfiles.GetById(user.Id);
                         
                var userDTO = CustomMapperBLL._fromClientProfileToUserDTO.CreateMapper().Map<UserProfile, UserDTO>(profile); //  mapper.Map<UserDTO>(user.UserProfile);
                userDTO.Roles = result1;
                return userDTO;   
            }
            return null;
        }

        public async Task<IdentityResult> Register(UserRegisterDTO user)
        {
            //ApplicationUser appUser = await userManager.FindByEmailAsync(user.Email);
            //if (appUser == null)
            //{
                //ApplicationUser userCreate = mapper.Map<ApplicationUser>(user);

                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = user.Email,
                    Email = user.Email
                };
                var result = await userManager.CreateAsync(applicationUser, user.Password);

                if (result.Succeeded)
                {
                   // appUser = await userManager.FindByEmailAsync(user.Email);
                    await userManager.AddToRoleAsync(applicationUser, "Member");

                    UserProfile userProfile = new UserProfile()
                    {
                    Name = user.Name,
                    Surname = user.Surname,
                    User = applicationUser

                    };

                    unitOfWork.UserProfiles.Create(userProfile);
                    unitOfWork.SaveChanges();
                }


                
                //UserProfile userProfile = new UserProfile()
                //{
                //    Id = applicationUser.Id;
                //};

                return result;
            //}
            //else
            //{
            //    return IdentityResult.Failed(new IdentityError() { Description = "The user is already exists" });
            //}
            //return IdentityResult.Success;
        }
    }
}
