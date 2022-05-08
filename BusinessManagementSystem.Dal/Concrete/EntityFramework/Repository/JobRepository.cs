﻿using BusinessManagementSystem.Dal.Abstract;
using BusinessManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Dal.Concrete.EntityFramework.Repository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly DbContext context;
        public JobRepository(DbContext context) : base(context)
        {
            this.context = context;
        }


    }
}
