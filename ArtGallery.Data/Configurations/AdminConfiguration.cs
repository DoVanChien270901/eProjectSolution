﻿using ArtGallery.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(c => c.Name);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Password).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.Role).WithMany(c => c.Admin).HasForeignKey(c => c.RoleId);
        }
    }
}
