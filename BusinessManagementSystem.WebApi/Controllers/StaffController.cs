using BusinessManagementSystem.Entity.Base;
using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.IBase;
using BusinessManagementSystem.Entity.Models;
using BusinessManagementSystem.Interface;
using BusinessManagementSystem.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StaffController : ApiBaseController<IStaffService, Staff, DtoStaff>
    {
        private readonly IStaffService staffService;
        public StaffController(IStaffService staffService) : base(staffService)
        {
            this.staffService = staffService;
        }

 
    }
}
