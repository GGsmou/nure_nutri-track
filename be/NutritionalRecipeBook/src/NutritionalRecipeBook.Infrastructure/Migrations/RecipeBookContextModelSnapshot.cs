﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionalRecipeBook.Infrastructure;

#nullable disable

namespace NutritionalRecipeBook.Infrastructure.Migrations
{
    [DbContext(typeof(RecipeBookContext))]
    partial class RecipeBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.CalorieNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Calorie")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CalorieNote");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.ExercisesNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("ExercisesNote");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Hydration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Intake")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Hydration");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("07635319-6b55-4cb2-ba37-611f771aeb57"),
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = new Guid("b3dc04e0-a4c9-4929-957d-c509e9a1b4c5"),
                            Name = "Lettuce"
                        },
                        new
                        {
                            Id = new Guid("28dee073-6556-46bb-9055-71f9d536e947"),
                            Name = "Cucumber"
                        },
                        new
                        {
                            Id = new Guid("bfa0ca70-344c-4641-8685-dc834e5a5f8b"),
                            Name = "Carrot"
                        },
                        new
                        {
                            Id = new Guid("7c753fe6-5409-444c-95c6-e5adaf71ebc6"),
                            Name = "Onion"
                        },
                        new
                        {
                            Id = new Guid("a515d859-e2fa-4bd7-803c-f169281b50b4"),
                            Name = "Garlic"
                        },
                        new
                        {
                            Id = new Guid("e018ddca-c0dc-4a6c-99aa-ee54714f0560"),
                            Name = "Bell Pepper"
                        });
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar");

                    b.Property<bool?>("IsCreatedByUser")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Votes")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.RecipeComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipeComment");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserHydration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HydrationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HydrationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHydrations");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserIngredient", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBougth")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("UserIngredients");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserRecipe", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CCalorieNoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CalorieNoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeId", "UserId");

                    b.HasIndex("CalorieNoteId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRecipes");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AteHealthy")
                        .HasColumnType("bit");

                    b.Property<bool>("Chef")
                        .HasColumnType("bit");

                    b.Property<bool>("Critic")
                        .HasColumnType("bit");

                    b.Property<bool>("CriticTwoPointO")
                        .HasColumnType("bit");

                    b.Property<int>("DailyCalories")
                        .HasColumnType("int");

                    b.Property<double>("DesiredWeight")
                        .HasColumnType("float");

                    b.Property<bool>("Exercised")
                        .HasColumnType("bit");

                    b.Property<bool>("Hydrated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("Social")
                        .HasColumnType("bit");

                    b.Property<int>("Subscription")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserTypeIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("UserTypeIngredient");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.WaterNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Ml")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WaterNote");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.ExercisesNote", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("ExercisesNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.RecipeComment", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("RecipeComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Review", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserHydration", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Hydration", "Hydration")
                        .WithMany()
                        .HasForeignKey("HydrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("Hydrations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hydration");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserIngredient", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("ShoppingList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserRecipe", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.CalorieNote", "CalorieNote")
                        .WithMany()
                        .HasForeignKey("CalorieNoteId");

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("FavoriteRecipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalorieNote");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserType", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithOne("UserType")
                        .HasForeignKey("NutritionalRecipeBook.Domain.Entities.UserType", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserTypeIngredient", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionalRecipeBook.Domain.Entities.UserType", "UserType")
                        .WithMany("BannedIngredients")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.WaterNote", b =>
                {
                    b.HasOne("NutritionalRecipeBook.Domain.Entities.User", "User")
                        .WithMany("WaterNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.User", b =>
                {
                    b.Navigation("ExercisesNotes");

                    b.Navigation("FavoriteRecipes");

                    b.Navigation("Hydrations");

                    b.Navigation("RecipeComments");

                    b.Navigation("ShoppingList");

                    b.Navigation("UserType");

                    b.Navigation("WaterNotes");
                });

            modelBuilder.Entity("NutritionalRecipeBook.Domain.Entities.UserType", b =>
                {
                    b.Navigation("BannedIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
