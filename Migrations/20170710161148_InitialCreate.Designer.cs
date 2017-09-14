using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SkillsMatrixApi.Models;

namespace SkillsMatrixApi.Migrations
{
    [DbContext(typeof(SkillsMatrixContext))]
    [Migration("20170710161148_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("SkillsMatrixApi.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("SkillsMatrixApi.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("SkillId");

                    b.HasKey("EmployeeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("employee_skill");
                });

            modelBuilder.Entity("SkillsMatrixApi.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("skill");
                });

            modelBuilder.Entity("SkillsMatrixApi.Models.EmployeeSkill", b =>
                {
                    b.HasOne("SkillsMatrixApi.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkillsMatrixApi.Models.Skill", "Skill")
                        .WithMany("SkillEmployees")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
