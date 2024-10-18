﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoSlices.API.Data;

#nullable disable

namespace TodoSlices.API.Migrations
{
    [DbContext(typeof(TodoSlicesDatabaseContext))]
    partial class TodoSlicesDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TodoSlices.API.Entities.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("WorkspaceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.EntryColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("EntryColumns");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.EntryRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EntryColumnId")
                        .HasColumnType("char(36)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EntryColumnId");

                    b.ToTable("EntryRows");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.Workspace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.Board", b =>
                {
                    b.HasOne("TodoSlices.API.Entities.Workspace", "Workspace")
                        .WithMany("Boards")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.EntryColumn", b =>
                {
                    b.HasOne("TodoSlices.API.Entities.Board", "Board")
                        .WithMany("EntryColumns")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.EntryRow", b =>
                {
                    b.HasOne("TodoSlices.API.Entities.EntryColumn", "EntryColumn")
                        .WithMany("EntryRows")
                        .HasForeignKey("EntryColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryColumn");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.Board", b =>
                {
                    b.Navigation("EntryColumns");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.EntryColumn", b =>
                {
                    b.Navigation("EntryRows");
                });

            modelBuilder.Entity("TodoSlices.API.Entities.Workspace", b =>
                {
                    b.Navigation("Boards");
                });
#pragma warning restore 612, 618
        }
    }
}
