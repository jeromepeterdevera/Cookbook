﻿// <auto-generated />
using System;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    [DbContext(typeof(CookbookDbContext))]
    [Migration("20190417190638_AddIndexingToJoinTables")]
    partial class AddIndexingToJoinTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.Cook", b =>
                {
                    b.Property<int>("CookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("CookId");

                    b.ToTable("Cook","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("IngredientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredient","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.PreparedRecipe", b =>
                {
                    b.Property<int>("PreparedRecipeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<bool>("Complete");

                    b.Property<int>("CookId");

                    b.Property<DateTime>("PreparedWhen");

                    b.Property<int?>("RecipeId");

                    b.HasKey("PreparedRecipeId");

                    b.HasIndex("CookId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("Alias", "CookId")
                        .IsUnique();

                    b.ToTable("PreparedRecipe","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.PreparedRecipeIngredient", b =>
                {
                    b.Property<int>("PreparedRecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IngredientId");

                    b.Property<int>("PreparedRecipeId");

                    b.HasKey("PreparedRecipeIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PreparedRecipeId", "IngredientId")
                        .IsUnique()
                        .HasFilter("[IngredientId] IS NOT NULL");

                    b.ToTable("PreparedRecipeIngredient","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CookId");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("RecipeId");

                    b.HasIndex("CookId");

                    b.HasIndex("Name", "CookId")
                        .IsUnique();

                    b.ToTable("Recipe","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientId");

                    b.Property<int>("RecipeId");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId", "IngredientId")
                        .IsUnique();

                    b.ToTable("RecipeIngredient","Recipe");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.PreparedRecipe", b =>
                {
                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Cook", "Cook")
                        .WithMany("PreparedRecipes")
                        .HasForeignKey("CookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Recipe", "Recipe")
                        .WithMany("PreparedRecipes")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.PreparedRecipeIngredient", b =>
                {
                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Ingredient", "Ingredient")
                        .WithMany("PreparedRecipeIngredients")
                        .HasForeignKey("IngredientId");

                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.PreparedRecipe", "PreparedRecipe")
                        .WithMany("PreparedRecipeIngredients")
                        .HasForeignKey("PreparedRecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.Recipe", b =>
                {
                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Cook", "Cook")
                        .WithMany("Recipes")
                        .HasForeignKey("CookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookbook.WebApi.DataAccessLayer.Models.RecipeIngredient", b =>
                {
                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookbook.WebApi.DataAccessLayer.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
