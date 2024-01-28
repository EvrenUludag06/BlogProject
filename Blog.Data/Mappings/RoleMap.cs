﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity.Entities;

namespace Blog.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
            builder.ToTable("AspNetRoles");
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            builder.HasData(new AppRole
            {
                Id = Guid.Parse("16EA936C-7A28-4C30-86A2-9A9704B6115E"),
                Name = "Superadmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new AppRole
            {
                Id = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC3AEFB"),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}