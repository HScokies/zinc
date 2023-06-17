﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using zinc_api.Services;

#nullable disable

namespace zinc_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("zinc_api.Models.Entities.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("department");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "OBG"
                        },
                        new
                        {
                            id = 2,
                            name = "VELC"
                        },
                        new
                        {
                            id = 3,
                            name = "GMC"
                        },
                        new
                        {
                            id = 4,
                            name = "SKC"
                        },
                        new
                        {
                            id = 5,
                            name = "HVP"
                        },
                        new
                        {
                            id = 6,
                            name = "VYSH"
                        },
                        new
                        {
                            id = 7,
                            name = "KEC"
                        });
                });

            modelBuilder.Entity("zinc_api.Models.Entities.GMC_Larox", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("gmc_larox");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.GMC_Velc1", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("gmc_velc1");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.GMC_Velc2", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("gmc_velc2");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.HVP", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("hvp");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.KEC1", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("kec1");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.KEC2", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("kec2");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.KEC_Kadmievoe", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("kec_kadmievoe");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.OBG1", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("obg1");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.OBG2", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("obg2");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.SKC1", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("skc1");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.SKC2", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("skc2");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Station", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("departmentid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name_table")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("departmentid");

                    b.ToTable("station");

                    b.HasData(
                        new
                        {
                            id = 1,
                            departmentid = 1,
                            name = "IUS_OBG511",
                            name_table = "OBG1"
                        },
                        new
                        {
                            id = 2,
                            departmentid = 1,
                            name = "IUS_OBG52",
                            name_table = "OBG2"
                        },
                        new
                        {
                            id = 3,
                            departmentid = 2,
                            name = "IUS_VELC1",
                            name_table = "GMC_Velc1"
                        },
                        new
                        {
                            id = 4,
                            departmentid = 2,
                            name = "IUS_VELC2",
                            name_table = "GMC_Velc2"
                        },
                        new
                        {
                            id = 5,
                            departmentid = 2,
                            name = "VELC5PC21",
                            name_table = "Velc_KVP5"
                        },
                        new
                        {
                            id = 6,
                            departmentid = 2,
                            name = "KVP61",
                            name_table = "Velc_KVP6"
                        },
                        new
                        {
                            id = 7,
                            departmentid = 3,
                            name = "IUS_VELC1",
                            name_table = "GMC_Velc1"
                        },
                        new
                        {
                            id = 8,
                            departmentid = 3,
                            name = "IUS_VELC2",
                            name_table = "GMC_Velc2"
                        },
                        new
                        {
                            id = 9,
                            departmentid = 3,
                            name = "LAROX",
                            name_table = "GMC_Larox"
                        },
                        new
                        {
                            id = 10,
                            departmentid = 4,
                            name = "IUS_SKC42",
                            name_table = "SKC1"
                        },
                        new
                        {
                            id = 11,
                            departmentid = 4,
                            name = "IUS_SKC43",
                            name_table = "SKC2"
                        },
                        new
                        {
                            id = 12,
                            departmentid = 5,
                            name = "HVP_station",
                            name_table = "HVP"
                        },
                        new
                        {
                            id = 13,
                            departmentid = 6,
                            name = "IUS_V5",
                            name_table = "Vysh"
                        },
                        new
                        {
                            id = 14,
                            departmentid = 7,
                            name = "CHPEW2",
                            name_table = "KEC1"
                        },
                        new
                        {
                            id = 15,
                            departmentid = 7,
                            name = "CHPEW3",
                            name_table = "KEC2"
                        },
                        new
                        {
                            id = 16,
                            departmentid = 7,
                            name = "KADMIEVOE",
                            name_table = "KEC_Kadmievoe"
                        });
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Tech_pok", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("num")
                        .HasColumnType("integer");

                    b.Property<int>("station_id")
                        .HasColumnType("integer");

                    b.Property<int>("stationid")
                        .HasColumnType("integer");

                    b.Property<string>("uom")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("stationid");

                    b.ToTable("tech_pok");
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Velc_KVP5", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("velc_kvp5");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Velc_KVP6", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("velc_kvp6");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Vysh", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<short>("num")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("val")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("vysh");

                    NpgsqlEntityTypeBuilderExtensions.IsUnlogged(b, true);
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Station", b =>
                {
                    b.HasOne("zinc_api.Models.Entities.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("zinc_api.Models.Entities.Tech_pok", b =>
                {
                    b.HasOne("zinc_api.Models.Entities.Station", "station")
                        .WithMany()
                        .HasForeignKey("stationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("station");
                });
#pragma warning restore 612, 618
        }
    }
}
