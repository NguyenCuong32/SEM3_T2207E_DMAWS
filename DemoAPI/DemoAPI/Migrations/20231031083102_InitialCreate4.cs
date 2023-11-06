using Microsoft.EntityFrameworkCore.Migrations;
using DemoAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using DemoAPI.Models;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");
        }
    }


public static class UserModelEndpoints
{
	public static void MapUserModelEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserModel").WithTags(nameof(UserModel));

        group.MapGet("/", async (UserDbContext db) =>
        {
            return await db.Users.ToListAsync();
        })
        .WithName("GetAllUserModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<UserModel>, NotFound>> (int id, UserDbContext db) =>
        {
            return await db.Users.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is UserModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, UserModel userModel, UserDbContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, userModel.Id)
                  .SetProperty(m => m.Name, userModel.Name)
                  .SetProperty(m => m.Address, userModel.Address)
                  .SetProperty(m => m.Age, userModel.Age)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUserModel")
        .WithOpenApi();

        group.MapPost("/", async (UserModel userModel, UserDbContext db) =>
        {
            db.Users.Add(userModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/UserModel/{userModel.Id}",userModel);
        })
        .WithName("CreateUserModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, UserDbContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUserModel")
        .WithOpenApi();
    }
}}
