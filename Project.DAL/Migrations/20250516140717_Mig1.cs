﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrideName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumCompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCategories_AlbumCompanies_AlbumCompanyId",
                        column: x => x.AlbumCompanyId,
                        principalTable: "AlbumCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraServices_ExtraServiceCategories_ExtraServiceCategoryId",
                        column: x => x.ExtraServiceCategoryId,
                        principalTable: "ExtraServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    PackageOptionId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_PackageOptions_PackageOptionId",
                        column: x => x.PackageOptionId,
                        principalTable: "PackageOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SizeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOptions_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "money", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "money", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ExtraServiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationExtras_ExtraServices_ExtraServiceId",
                        column: x => x.ExtraServiceId,
                        principalTable: "ExtraServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationExtras_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlbumCompanies",
                columns: new[] { "Id", "Address", "ContactPersonEmail", "ContactPersonName", "ContactPersonPhone", "CreatedDate", "DeletedDate", "Email", "ModifiedDate", "Name", "Phone", "Status" },
                values: new object[] { 1, "Karayolları Mah. 559 Sk. No:18/1 G.O.PAŞA / İSTANBUL / TÜRKİYE", "cizgialbum@gmail.com", "Test", "+905359750193", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3510), null, "cizgialbum@gmail.com", null, "ÇİZGİ ALBÜM FOTOĞRAFÇILIK", "+02125387994", 1 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "526b9bce-c59c-4a2f-9d4e-a99cc0703890", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "2494aab1-f536-475e-a804-2924eacae883", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3366), null, "fotoeylul@email.com", true, false, null, null, "FOTOEYLUL@EMAIL.COM", "FOTOEYLUL", "AQAAAAIAAYagAAAAEFMVtCso8NL189pDOKyArskaHMQXXVN8CNrbsspozT0doJ6sqVnt5jSY+eWn2tLrhw==", null, false, "d8be4fb8-3fdd-4aab-b728-0639a9a10809", 1, false, "fotoeylul" });

            migrationBuilder.InsertData(
                table: "ExtraServiceCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Kanvas", 1 },
                    { 2, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Poster", 1 },
                    { 3, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Saat", 1 },
                    { 4, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Lüx Çerçeve", 1 },
                    { 5, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Lake Çerçeve", 1 },
                    { 6, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3651), null, null, "Oval Çerçeve", 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "DeletedDate", "District", "IsFree", "ModifiedDate", "Name", "Phone", "Price", "Status" },
                values: new object[,]
                {
                    { 1, "Yan Yol, Ataşehir, Rıfat Danışman Sok., 34758", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Ataşehir", true, null, "Nezahat Gökyiğit Botanik Bahçesi", "02164564437", null, 1 },
                    { 2, "Küçük Çamlıca, 34696", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Üsküdar", true, null, "Küçük Çamlıca", null, null, 1 },
                    { 3, "Kandilli, Vaniköy Cd No : 12, 34684", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Üsküdar", true, null, "Adile Sultan Kasrı", "(0216) 332 23 33", null, 1 },
                    { 4, "Yıldız, Çırağan Cd., 34349", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Beşiktaş", true, null, "Yıldız Parkı", null, null, 1 },
                    { 5, "Piri Paşa, Rahmi M. Koç Caddesi No: 3, 34445", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Beyoğlu", false, null, "Rahmi M. Koç Müzesi", "(0212) 369 66 00", 600.00m, 1 },
                    { 6, "Reşitpaşa, Emirgan Sk., 34467", "İstanbul", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3565), null, "Sarıyer", true, null, "Emirgan Korusu", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Fee", "FirstName", "LastName", "ModifiedDate", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3531), null, 2000.00m, "Hakan", "Akınsu", new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3531), "05538971905", 2 },
                    { 2, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3531), null, 5000.00m, "Mustafa Osman", "Kaya", null, "05538275858", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ExtraServices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ExtraServiceCategoryId", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), "30x40 Kanvas", 600.00m, 1 },
                    { 2, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), "50x60 Kanvas", 950.00m, 1 },
                    { 3, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, null, "50x70 Kanvas", 950.00m, 1 },
                    { 4, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), "70x100 Kanvas", 1200.00m, 1 },
                    { 5, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, null, "75x100 3 Parçalı Kanvas", 2200.00m, 1 },
                    { 6, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3748), null, 1, null, "75x125 5 Parçalı Kanvas", 3200.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "AlbumCompanyId", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3677), null, null, "New Line Collection", 1 },
                    { 2, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3677), null, null, "Standart Seri", 1 },
                    { 3, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3677), null, null, "Kampanya Seri", 1 },
                    { 4, 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3677), null, null, "Çizgi Avantaj Seri", 1 }
                });

            migrationBuilder.InsertData(
                table: "SizeOptions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Dimension", "ModifiedDate", "ServiceCategoryId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x70 New Line", null, 1, 1 },
                    { 2, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x60 New Line", null, 1, 1 },
                    { 3, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x80 New Line", null, 1, 1 },
                    { 4, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x70 Standart", null, 2, 1 },
                    { 5, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x50 Standart", null, 2, 1 },
                    { 6, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x60 Standart", null, 2, 1 },
                    { 7, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x60 Standart", null, 2, 1 },
                    { 8, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x80 Standart", null, 2, 1 },
                    { 9, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x60 Kampanya", null, 3, 1 },
                    { 10, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x50 Kampanya", null, 3, 1 },
                    { 11, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x70 Kampanya", null, 3, 1 },
                    { 12, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x50 Kampanya", null, 3, 1 },
                    { 13, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x60 Kampanya", null, 3, 1 },
                    { 14, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x76 Kampanya", null, 3, 1 },
                    { 15, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x80 Kampanya", null, 3, 1 },
                    { 16, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x70 Çizgi Avantaj", null, 4, 1 },
                    { 17, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x60 Çizgi Avantaj", null, 4, 1 },
                    { 18, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x70 Çizgi Avantaj", null, 4, 1 },
                    { 19, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x50 Çizgi Avantaj", null, 4, 1 },
                    { 20, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "25x60 Çizgi Avantaj", null, 4, 1 },
                    { 21, new DateTime(2025, 5, 16, 17, 7, 17, 498, DateTimeKind.Local).AddTicks(3697), null, "30x50 Çizgi Avantaj", null, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraServices_ExtraServiceCategoryId",
                table: "ExtraServices",
                column: "ExtraServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationExtras_ExtraServiceId",
                table: "ReservationExtras",
                column: "ExtraServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationExtras_ReservationId",
                table: "ReservationExtras",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PackageOptionId",
                table: "Reservations",
                column: "PackageOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PhotographerId",
                table: "Reservations",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceCategoryId",
                table: "Reservations",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_AlbumCompanyId",
                table: "ServiceCategories",
                column: "AlbumCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOptions_ServiceCategoryId",
                table: "SizeOptions",
                column: "ServiceCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ReservationExtras");

            migrationBuilder.DropTable(
                name: "SizeOptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ExtraServiceCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PackageOptions");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "AlbumCompanies");
        }
    }
}
