﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("WebApplication1.Data.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("S1")
                        .HasColumnType("REAL");

                    b.Property<double>("S2")
                        .HasColumnType("REAL");

                    b.Property<double>("d")
                        .HasColumnType("REAL");

                    b.Property<double>("t")
                        .HasColumnType("REAL");

                    b.Property<double>("w")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
