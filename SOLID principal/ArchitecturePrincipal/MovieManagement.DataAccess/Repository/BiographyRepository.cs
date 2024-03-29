﻿using MovieManagement.DataAccess.Context;
using MovieManagementDomain.Entities;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Repository
{
    public class BiographyRepository : GenericRepository<Biography>, IBiographyRepository
    {
        public BiographyRepository(MovieManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}
