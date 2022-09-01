﻿using DataAccessLayer.IRepositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmploymentDetailsRepository : GenericRepository<EmploymentDetails>, IEmploymentDetailsRepository
    {
        public EmploymentDetailsRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
        }
    }
}
