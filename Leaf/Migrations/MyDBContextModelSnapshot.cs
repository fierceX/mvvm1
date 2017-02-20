﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Leaf.Model;

namespace Leaf.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Leaf.Model.GapFilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("Level");

                    b.Property<string>("Stems");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("GapFillings");
                });

            modelBuilder.Entity("Leaf.Model.GapTest", b =>
                {
                    b.Property<int>("GapId");

                    b.Property<int>("TestId");

                    b.HasKey("GapId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("GapTest");
                });

            modelBuilder.Entity("Leaf.Model.SingleChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("Choices1");

                    b.Property<string>("Choices2");

                    b.Property<string>("Choices3");

                    b.Property<int>("Level");

                    b.Property<string>("Stems");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("SingleChoices");
                });

            modelBuilder.Entity("Leaf.Model.SingleTest", b =>
                {
                    b.Property<int>("SingleId");

                    b.Property<int>("TestId");

                    b.HasKey("SingleId", "TestId");

                    b.HasIndex("TestId");

                    b.ToTable("SingleTest");
                });

            modelBuilder.Entity("Leaf.Model.TestPaper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuildTime");

                    b.Property<int>("GapNum");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Score");

                    b.Property<int>("SingleNum");

                    b.Property<int>("Time");

                    b.HasKey("Id");

                    b.ToTable("TestPapers");
                });

            modelBuilder.Entity("Leaf.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Admin");

                    b.Property<string>("BuildTime");

                    b.Property<string>("Password");

                    b.Property<string>("Score");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Leaf.Model.GapTest", b =>
                {
                    b.HasOne("Leaf.Model.GapFilling", "gap")
                        .WithMany("testpapers")
                        .HasForeignKey("GapId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Leaf.Model.TestPaper", "test")
                        .WithMany("gapfills")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Leaf.Model.SingleTest", b =>
                {
                    b.HasOne("Leaf.Model.SingleChoice", "single")
                        .WithMany("testpapers")
                        .HasForeignKey("SingleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Leaf.Model.TestPaper", "test")
                        .WithMany("singles")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
