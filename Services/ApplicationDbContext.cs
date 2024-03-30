﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineInternship.Models;

namespace OnlineInternship.Services
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var applicant = new IdentityRole("applicant");
            applicant.NormalizedName = "applicant";

            var InternshipCordinator = new IdentityRole("InternshipCordinator");
            InternshipCordinator.NormalizedName = "InternshipCordinator";

            var organization = new IdentityRole("organization");
            organization.NormalizedName = "organization";

            builder.Entity<IdentityRole>().HasData(admin, applicant, InternshipCordinator, organization);
        }
        

    }
}
