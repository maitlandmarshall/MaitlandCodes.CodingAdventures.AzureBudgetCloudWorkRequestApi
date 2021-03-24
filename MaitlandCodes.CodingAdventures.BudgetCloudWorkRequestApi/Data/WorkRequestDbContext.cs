using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MaitlandCodes.CodingAdventures.BudgetCloudWorkRequestApi.Data
{
    public class WorkRequestDbContext : DbContext
    {
        public WorkRequestDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<WorkRequest> WorkRequests { get; set; }
    }
}
