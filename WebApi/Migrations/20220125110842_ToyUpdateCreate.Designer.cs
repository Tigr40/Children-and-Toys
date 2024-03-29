﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Persistance;

namespace WebApi.Migrations
{
    [DbContext(typeof(KinderGartenContext))]
    [Migration("20220125110842_ToyUpdateCreate")]
    partial class ToyUpdateCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");

            modelBuilder.Entity("WebApi.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("children");
                });

            modelBuilder.Entity("WebApi.Models.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Condition")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OwnerIdId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerIdId");

                    b.ToTable("toys");
                });

            modelBuilder.Entity("WebApi.Models.Toy", b =>
                {
                    b.HasOne("WebApi.Models.Child", "OwnerId")
                        .WithMany()
                        .HasForeignKey("OwnerIdId");

                    b.Navigation("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
