﻿// <auto-generated />
using System;
using LibraryBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryBook.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220616115737_file")]
    partial class file
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryBook.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryBook.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAuthor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Pages")
                        .HasColumnType("bigint");

                    b.Property<string>("TextFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryBook.Models.BookAut", b =>
                {
                    b.Property<int>("idAuthor")
                        .HasColumnType("int");

                    b.Property<int>("idBook")
                        .HasColumnType("int");

                    b.Property<int?>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int?>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("idAuthor", "idBook");

                    b.HasIndex("AuthorsId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookAuts");
                });

            modelBuilder.Entity("LibraryBook.Models.GenBook", b =>
                {
                    b.Property<int>("idGenre")
                        .HasColumnType("int");

                    b.Property<int>("idBook")
                        .HasColumnType("int");

                    b.Property<int?>("BooksId")
                        .HasColumnType("int");

                    b.Property<int?>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("idGenre", "idBook");

                    b.HasIndex("BooksId");

                    b.HasIndex("GenresId");

                    b.ToTable("GenBooks");
                });

            modelBuilder.Entity("LibraryBook.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("LibraryBook.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("LibraryBook.Models.RateBook", b =>
                {
                    b.Property<int>("idRate")
                        .HasColumnType("int");

                    b.Property<int>("idBook")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<int?>("BooksId")
                        .HasColumnType("int");

                    b.Property<int?>("RatesId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersidRole")
                        .HasColumnType("int");

                    b.HasKey("idRate", "idBook", "idUser");

                    b.HasIndex("BooksId");

                    b.HasIndex("RatesId");

                    b.HasIndex("UsersidRole");

                    b.ToTable("RateBooks");
                });

            modelBuilder.Entity("LibraryBook.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LibraryBook.Models.User", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRole"), 1L, 1);

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Login")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("idRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryBook.Models.Book", b =>
                {
                    b.HasOne("LibraryBook.Models.Author", "Author")
                        .WithMany("Book")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LibraryBook.Models.BookAut", b =>
                {
                    b.HasOne("LibraryBook.Models.Author", "Authors")
                        .WithMany()
                        .HasForeignKey("AuthorsId");

                    b.HasOne("LibraryBook.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksId");

                    b.Navigation("Authors");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryBook.Models.GenBook", b =>
                {
                    b.HasOne("LibraryBook.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksId");

                    b.HasOne("LibraryBook.Models.Genre", "Genres")
                        .WithMany()
                        .HasForeignKey("GenresId");

                    b.Navigation("Books");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("LibraryBook.Models.RateBook", b =>
                {
                    b.HasOne("LibraryBook.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksId");

                    b.HasOne("LibraryBook.Models.Rate", "Rates")
                        .WithMany()
                        .HasForeignKey("RatesId");

                    b.HasOne("LibraryBook.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersidRole");

                    b.Navigation("Books");

                    b.Navigation("Rates");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryBook.Models.Author", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
