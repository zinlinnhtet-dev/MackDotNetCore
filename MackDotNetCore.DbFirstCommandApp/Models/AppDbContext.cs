﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MackDotNetCore.DbFirstCommandApp.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database= TestDb;User ID=sa;Password=sa@123;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogId).HasColumnName("Blog_Id");
            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .HasColumnName("Blog_Author");
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .HasColumnName("Blog_Content");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .HasColumnName("Blog_Title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
