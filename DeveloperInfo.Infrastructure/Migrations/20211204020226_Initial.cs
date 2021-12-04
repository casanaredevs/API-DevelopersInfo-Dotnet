using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperInfo.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperSocialNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialNetworkId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperSocialNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperSocialNetworks_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperSocialNetworks_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTechnology",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnologyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTechnology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperTechnology_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTechnology_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07cbeefd-bcb7-4d31-ad5c-ad6286a4818e"), "whatsapp" },
                    { new Guid("415fdd0c-670a-41e4-8feb-996e55c06825"), "github" },
                    { new Guid("5a9c90a4-970c-4379-b0ca-6b2e32f2b39f"), "facebook" },
                    { new Guid("5c4fea1c-ffd8-466f-bc59-877169af3f0e"), "instagram" },
                    { new Guid("c6c7569f-efd7-405b-8534-716ed0b15747"), "telegram" },
                    { new Guid("e1aadc92-4845-44cc-a6aa-ad482dcc4604"), "linked_in" },
                    { new Guid("f1b00491-6418-4cf9-9bd1-f387f59e9eeb"), "twitter" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f466aab-935c-4ddb-a1da-76e7008ef6f5"), "vuejs" },
                    { new Guid("1950191e-4dd7-4eae-b9a5-627de1374a0a"), "c_sharp" },
                    { new Guid("1d02fef3-1234-4123-9fdb-0786e1a2577c"), "java" },
                    { new Guid("1d32c8dd-e678-4c2b-84f0-ebf4be54d2c9"), "javascript" },
                    { new Guid("31742697-8d3c-4803-9fc8-16ae6764e070"), "blazor" },
                    { new Guid("3321884d-56c8-448e-b75f-79ad57cc132a"), "django" },
                    { new Guid("3602404d-9383-4940-84bc-39abbf6c5f1b"), "nodejs" },
                    { new Guid("58b2bf1a-b49c-4784-addb-ef86289ae2d4"), "flutter" },
                    { new Guid("7cfb814a-e3e1-45d5-a0e7-da32c1ff02ed"), "dart" },
                    { new Guid("935faf7d-9775-4952-9a3c-b2dd71227e26"), "php" },
                    { new Guid("96ebddf2-a988-4bd8-8657-019153518c10"), "python" },
                    { new Guid("9be041ea-84e5-4dbc-afa9-adfa650ba67f"), "net" },
                    { new Guid("a383d62f-b7dc-47e4-8553-c22374a2bd91"), "adonisjs" },
                    { new Guid("ab6d3278-7934-4b60-8eb5-f7b7d8e578a4"), "laravel" },
                    { new Guid("bb453778-eaa9-4974-98be-b844fa49337f"), "c_c_plusplus" },
                    { new Guid("c1afea03-a210-4a19-872e-97aeae89ec10"), "react" },
                    { new Guid("c27806d4-6554-45d5-8f8f-1a1a37cf3913"), "swift" },
                    { new Guid("c5e1a897-459a-48d1-a11e-12218b1f7dc5"), "typescript" },
                    { new Guid("da7c0c08-bb63-4bf0-ac11-f31b895c76fc"), "ionic" },
                    { new Guid("e79efe58-0efc-4d96-b0d4-5ec6aaed9911"), "nestjs" },
                    { new Guid("e81b307d-6f42-4a52-8d17-38cd1885e18a"), "objective_c" },
                    { new Guid("e885dc48-a075-45d1-8c5c-682d40c242fe"), "spring" },
                    { new Guid("ebeec377-39fc-447f-b791-caa4a55254f6"), "angular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSocialNetworks_DeveloperId",
                table: "DeveloperSocialNetworks",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSocialNetworks_SocialNetworkId",
                table: "DeveloperSocialNetworks",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTechnology_DeveloperId",
                table: "DeveloperTechnology",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTechnology_TechnologyId",
                table: "DeveloperTechnology",
                column: "TechnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperSocialNetworks");

            migrationBuilder.DropTable(
                name: "DeveloperTechnology");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
