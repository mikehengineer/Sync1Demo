using Microsoft.EntityFrameworkCore;
using Sync1Demo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sync1Demo.Data
{
    public class ApplicantDBContext : DbContext
    {

        public ApplicantDBContext(DbContextOptions<ApplicantDBContext> options)
            : base (options)
        {

        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
