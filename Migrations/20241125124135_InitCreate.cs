﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FADemo.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
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
                name: "AssetAlterModes",
                columns: table => new
                {
                    AssetAlterModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetAlterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetAlterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    IsAdd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAlterModes", x => x.AssetAlterModeId);
                });

            migrationBuilder.CreateTable(
                name: "AssetAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentHashCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentUploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttachmentUploadUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAttachments", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "AssetDeprmetHods",
                columns: table => new
                {
                    AssetDeprmetHodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetDeprmetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetDeprmetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetDeproption = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDeprmetHods", x => x.AssetDeprmetHodId);
                });

            migrationBuilder.CreateTable(
                name: "AssetPositions",
                columns: table => new
                {
                    AssetPositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetPositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetPositionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPositions", x => x.AssetPositionId);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatuses",
                columns: table => new
                {
                    AssetStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetStatusNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatuses", x => x.AssetStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    AssetTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetTypeCreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetTypeIsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.AssetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetCreateBases",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetRecordUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetRecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AssetDeprmetHodId = table.Column<int>(type: "int", nullable: true),
                    LastDeprmetHodDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetAlterModeId = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetStatusId = table.Column<int>(type: "int", nullable: true),
                    BeginUseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AssetPositionId = table.Column<int>(type: "int", nullable: true),
                    EmployeeReferenceId = table.Column<int>(type: "int", nullable: true),
                    AttachmentHashCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCreateBases", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_AssetAlterModes_AssetAlterModeId",
                        column: x => x.AssetAlterModeId,
                        principalTable: "AssetAlterModes",
                        principalColumn: "AssetAlterModeId");
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_AssetDeprmetHods_AssetDeprmetHodId",
                        column: x => x.AssetDeprmetHodId,
                        principalTable: "AssetDeprmetHods",
                        principalColumn: "AssetDeprmetHodId");
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_AssetPositions_AssetPositionId",
                        column: x => x.AssetPositionId,
                        principalTable: "AssetPositions",
                        principalColumn: "AssetPositionId");
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_AssetStatuses_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatuses",
                        principalColumn: "AssetStatusId");
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "AssetTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_AssetCreateBases_Employees_EmployeeReferenceId",
                        column: x => x.EmployeeReferenceId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "AssetUpdateDetails",
                columns: table => new
                {
                    AssetUpdateDeteailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssetAlterModeId = table.Column<int>(type: "int", nullable: true),
                    AssetStatusId = table.Column<int>(type: "int", nullable: true),
                    AssetPositionId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    EmployeeReferenceId = table.Column<int>(type: "int", nullable: true),
                    AssetUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentHashCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetUpdateDetails", x => x.AssetUpdateDeteailId);
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_AssetAlterModes_AssetAlterModeId",
                        column: x => x.AssetAlterModeId,
                        principalTable: "AssetAlterModes",
                        principalColumn: "AssetAlterModeId");
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_AssetCreateBases_AssetId",
                        column: x => x.AssetId,
                        principalTable: "AssetCreateBases",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_AssetPositions_AssetPositionId",
                        column: x => x.AssetPositionId,
                        principalTable: "AssetPositions",
                        principalColumn: "AssetPositionId");
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_AssetStatuses_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatuses",
                        principalColumn: "AssetStatusId");
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_AssetUpdateDetails_Employees_EmployeeReferenceId",
                        column: x => x.EmployeeReferenceId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
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
                name: "IX_AssetCreateBases_AssetAlterModeId",
                table: "AssetCreateBases",
                column: "AssetAlterModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_AssetDeprmetHodId",
                table: "AssetCreateBases",
                column: "AssetDeprmetHodId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_AssetPositionId",
                table: "AssetCreateBases",
                column: "AssetPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_AssetStatusId",
                table: "AssetCreateBases",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_AssetTypeId",
                table: "AssetCreateBases",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_DepartmentId",
                table: "AssetCreateBases",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCreateBases_EmployeeReferenceId",
                table: "AssetCreateBases",
                column: "EmployeeReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_AssetAlterModeId",
                table: "AssetUpdateDetails",
                column: "AssetAlterModeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_AssetId",
                table: "AssetUpdateDetails",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_AssetPositionId",
                table: "AssetUpdateDetails",
                column: "AssetPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_AssetStatusId",
                table: "AssetUpdateDetails",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_DepartmentId",
                table: "AssetUpdateDetails",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUpdateDetails_EmployeeReferenceId",
                table: "AssetUpdateDetails",
                column: "EmployeeReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
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
                name: "AssetAttachments");

            migrationBuilder.DropTable(
                name: "AssetUpdateDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AssetCreateBases");

            migrationBuilder.DropTable(
                name: "AssetAlterModes");

            migrationBuilder.DropTable(
                name: "AssetDeprmetHods");

            migrationBuilder.DropTable(
                name: "AssetPositions");

            migrationBuilder.DropTable(
                name: "AssetStatuses");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
