using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;


namespace BLL.Infrastructure
{
    public class CustomMapperBLL: Profile
    {
        public static MapperConfiguration _fromClientProfileToUserDTO;
        public static MapperConfiguration _fromCategoryToCategoryDTO;
        public static MapperConfiguration _fromQuestionToQuestionDTO;
        public static MapperConfiguration _fromCommentToCommentDTO;
        public static MapperConfiguration _fromRoleToRoleDTO;



        static CustomMapperBLL()
        {
            /* _fromClientProfileToUserDTO = new MapperConfiguration(cfg => 
             {
                 cfg.CreateMap<UserProfile, UserDTO>();
                 //.ForMember(d => d.Publications, a => a.Ignore())
                 //.ForMember(d => d.LikedPublications, a => a.Ignore())
                 //.ForMember(d => d.Followers, a => a.Ignore())
                 //.ForMember(d => d.Following, a => a.Ignore())
                 //.ForMember(d => d.MessageHeaders, a => a.Ignore());

                 //g.CreateMap<ApplicationUser, UserDTO>();

             });*/

            _fromClientProfileToUserDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserDTO>()
                    .ForMember(dest=>dest.UserName, opt=> opt.MapFrom(src=>src.User.UserName))
                    .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src =>src.Country.Id))
                    .ReverseMap();
                cfg.CreateMap<Country, CountryDTO>().ReverseMap();
                cfg.CreateMap<ApplicationRole, RoleDTO>().ReverseMap();
                cfg.CreateMap<ApplicationUser, UserDTO>()
                .ReverseMap();

             //   cfg.CreateMap<ApplicationUser, UserDTO>()
             //  .ForMember(dest => dest.RolesId, opt => opt.MapFrom(src =>src.ApplicationUserRoles))
             //.AfterMap(AddOrUpdateUserRoles);

                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();
                cfg.CreateMap<Question, QuestionDTO>().ReverseMap();
                cfg.CreateMap<QuestionToCreateDTO, Question>()
                .ReverseMap();



            });

            _fromCategoryToCategoryDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            });

            _fromQuestionToQuestionDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Country, CountryDTO>();
                cfg.CreateMap<UserProfile, UserDTO>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id))
                    .ReverseMap();
                cfg.CreateMap<Comment, CommentDTO>();
  
            });

            _fromCommentToCommentDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<UserProfile, UserDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });

            _fromRoleToRoleDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationRole, RoleDTO>().ReverseMap();
            });

        }

        //private static void AddOrUpdateUserRoles(ApplicationUser user, UserDTO userDto)
        //{
        //    foreach (var userRole in user.ApplicationUserRoles.Where(a=>a.UserId == user.Id))
        //    {

        //        userDto.RolesId.Add(userRole.RoleId);

        //    }
        //}

        private static void AddOrUpdateUserRoles(UserDTO dto, ApplicationUser user)
        {
           
        }

        public CustomMapperBLL()
        {
            //CreateMap<UserProfile, UserDTO>();
            //CreateMap<ApplicationUser, UserDTO>();


            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>();

        }

        public static CategoryDTO FromCategoryToCategoryDTO(Category source)
        {
            return _fromCategoryToCategoryDTO.CreateMapper().Map<Category, CategoryDTO>(source);
        }

        public static Category FromCategoryDTOToCategory(CategoryDTO source)
        {
            return _fromClientProfileToUserDTO.CreateMapper().Map<CategoryDTO, Category>(source);
        }

        public static IEnumerable<CategoryDTO> FromCategoryToCategoryDTO(IEnumerable<Category> categories)
        {
            List<CategoryDTO> result = new List<CategoryDTO>();
            foreach(var item in categories)
            {
                result.Add(FromCategoryToCategoryDTO(item));
            }

            return result;
        }

        public static QuestionDTO FromQuestionToQuestionDTO(Question question)
        {
            return _fromQuestionToQuestionDTO.CreateMapper().Map<Question, QuestionDTO>(question);
        }
        public static  IEnumerable<QuestionDTO> FromQuestionToQuestionDTO(IEnumerable<Question> questions)
        {
            List<QuestionDTO> result = new List<QuestionDTO>();
            foreach(var item in questions)
            {
                result.Add(FromQuestionToQuestionDTO(item));
            }

            return result;
        }

        public static CommentDTO FromCommentToCommentDTO(Comment question)
        {
            return _fromQuestionToQuestionDTO.CreateMapper().Map<Comment, CommentDTO>(question);
        }
        public static IEnumerable<CommentDTO> FromCommentToCommentDTO(IEnumerable<Comment> questions)
        {
            List<CommentDTO> result = new List<CommentDTO>();
            foreach (var item in questions)
            {
                result.Add(FromCommentToCommentDTO(item));
            }
            return result;
        }

        public static CountryDTO FromCountryToCountryDTO(Country question)
        {
            return _fromClientProfileToUserDTO.CreateMapper().Map<Country, CountryDTO>(question);
        }
        public static IEnumerable<CountryDTO> FromCountryToCountryDTO(IEnumerable<Country> questions)
        {
            List<CountryDTO> result = new List<CountryDTO>();
            foreach (var item in questions)
            {
                result.Add(FromCountryToCountryDTO(item));
            }
            return result;
        }

        public static UserProfile FromUserDTOToUserProfile(UserDTO question)
        {
            return _fromClientProfileToUserDTO.CreateMapper().Map<UserDTO, UserProfile>(question);
        }

        public static Question FromQuestionDTOToQuestion(QuestionToCreateDTO question)
        {
            return _fromClientProfileToUserDTO.CreateMapper().Map<QuestionToCreateDTO, Question>(question);
        }

        public static UserDTO FromUserToUserDTO(UserProfile userProfile)
        {
            var user = _fromClientProfileToUserDTO.CreateMapper().Map<UserProfile, UserDTO>(userProfile);
            return _fromClientProfileToUserDTO.CreateMapper().Map<UserProfile, UserDTO>(userProfile);
        }

        public static RoleDTO FromRoleToRoleDTO(ApplicationRole source)
        {
            return _fromRoleToRoleDTO.CreateMapper().Map<ApplicationRole, RoleDTO>(source);
        }

        public static IEnumerable<RoleDTO> FromRoleToRoleDTO(IEnumerable<ApplicationRole> source)
        {
            List<RoleDTO> result = new List<RoleDTO>();
            foreach (var item in source)
                result.Add(CustomMapperBLL.FromRoleToRoleDTO(item));
            return result;
        }
    }
}
