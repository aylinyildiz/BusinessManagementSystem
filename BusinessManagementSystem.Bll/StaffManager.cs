using BusinessManagementSystem.Dal.Abstract;
using BusinessManagementSystem.Entity.Base;
using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.IBase;
using BusinessManagementSystem.Entity.Models;
using BusinessManagementSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessManagementSystem.Bll
{
    public class StaffManager : GenericManager<Staff, DtoStaff>, IStaffService
    {
        public readonly IStaffRepository staffRepository;
        private IConfiguration configuration;

        public StaffManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            staffRepository = service.GetService<IStaffRepository>();
            this.configuration = configuration;

        }
        public IResponse<DtoStaffToken> Login(DtoLogin login)
        {
            var staff = staffRepository.Login(ObjectMapper.mapper.Map<Staff>(login));

            
            if(staff != null)
            {
                var dtoStaff = ObjectMapper.mapper.Map<DtoLoginStaff>(staff);
                var token = new TokenManager(configuration).CreateAccessToken(dtoStaff);

                var userToken = new DtoStaffToken()
                {
                    DtoLoginStaff = dtoStaff,
                    AccessToken = token
                };

                return new Response<DtoStaffToken>
                {
                    Message = "Token üretildi",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoStaffToken>
                {
                    Message = "Email veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }

        public IResponse<DtoRegister> Register(DtoRegister register)
        {

            Random rndpassword = new Random();
            register.password = Convert.ToString(rndpassword.Next(100000, 1000000)); //6haneli random parola üretildi.
 
            var registerStaff = staffRepository.Register(ObjectMapper.mapper.Map<Staff>(register));

            if(registerStaff != null)
            {
                return new Response<DtoRegister>
                {
                    Message = "Personel eklendi",
                    StatusCode = StatusCodes.Status200OK,
                    Data = register
                };
            }
            else
            {
                return new Response<DtoRegister>
                {
                    Message = "Eklenmedi",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}
