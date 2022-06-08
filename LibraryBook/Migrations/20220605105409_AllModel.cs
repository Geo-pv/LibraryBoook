using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBook.Migrations
{
    public partial class AllModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<int>(type: "int", nullable: false),
                    NicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pages = table.Column<long>(type: "bigint", nullable: false),
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookAuts",
                columns: table => new
                {
                    idAuthor = table.Column<int>(type: "int", nullable: false),
                    idBook = table.Column<int>(type: "int", nullable: false),
                    AuthorsId = table.Column<int>(type: "int", nullable: true),
                    BooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuts", x => new { x.idAuthor, x.idBook });
                    table.ForeignKey(
                        name: "FK_BookAuts_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookAuts_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenBooks",
                columns: table => new
                {
                    idGenre = table.Column<int>(type: "int", nullable: false),
                    idBook = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: true),
                    BooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenBooks", x => new { x.idGenre, x.idBook });
                    table.ForeignKey(
                        name: "FK_GenBooks_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenBooks_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RateBooks",
                columns: table => new
                {
                    idRate = table.Column<int>(type: "int", nullable: false),
                    idBook = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    RatesId = table.Column<int>(type: "int", nullable: true),
                    BooksId = table.Column<int>(type: "int", nullable: true),
                    UsersidRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateBooks", x => new { x.idRate, x.idBook, x.idUser });
                    table.ForeignKey(
                        name: "FK_RateBooks_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RateBooks_Rates_RatesId",
                        column: x => x.RatesId,
                        principalTable: "Rates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RateBooks_Users_UsersidRole",
                        column: x => x.UsersidRole,
                        principalTable: "Users",
                        principalColumn: "idRole");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuts_AuthorsId",
                table: "BookAuts",
                column: "AuthorsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuts_BooksId",
                table: "BookAuts",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_GenBooks_BooksId",
                table: "GenBooks",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_GenBooks_GenresId",
                table: "GenBooks",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_RateBooks_BooksId",
                table: "RateBooks",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_RateBooks_RatesId",
                table: "RateBooks",
                column: "RatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RateBooks_UsersidRole",
                table: "RateBooks",
                column: "UsersidRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuts");

            migrationBuilder.DropTable(
                name: "GenBooks");

            migrationBuilder.DropTable(
                name: "RateBooks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
