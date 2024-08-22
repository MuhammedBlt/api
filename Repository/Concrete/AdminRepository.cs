using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities.Concrete;
using api.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Concrete
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly IAdminRepository _adminRespository;
        public AdminRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        
}}