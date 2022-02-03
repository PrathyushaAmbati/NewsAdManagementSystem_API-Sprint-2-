using Microsoft.EntityFrameworkCore;
using NewsAdManagementSystem_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsAdManagementSystem_DAL.Data
{
    public class ConnectionString:DbContext
    {
        public ConnectionString(DbContextOptions<ConnectionString>options):base(options)
        {

        }
        public DbSet<EmployDetails> EmployeeDetails { get; set; }
        public DbSet<AdvertisementDetailsClass> AdvertisementDetails { get; set; }
        public DbSet<CustomerDetailsClass> CustomerDetails { get; set; }
        public DbSet<CustomerAdDetailsClass> CustomerAdDetails { get; set; }
    }
}
