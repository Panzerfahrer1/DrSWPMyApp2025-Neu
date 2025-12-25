using _01RestApi.Classes;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();

app.MapGet("/", () => "Hello World!");

app.MapPut("/users/{id}", (int id, User updateUser) => {
    if (users.Count(x => x.Email == updateUser.Email) > 1) {
        return Results.BadRequest();
    }

    User user = users.FirstOrDefault(u => u.Id == id);

    if (user == null) {
        return Results.NotFound(null);
    }

    if (!updateUser.Email.Contains("@")) {
        return Results.BadRequest("...---...");
    }

    user.Name = updateUser.Name;
    user.Email = updateUser.Email;
    user.BirthDate = updateUser.BirthDate;

    return Results.Created();
});

app.MapPost("/users", (User user) => {
    if (user == null) {
        return Results.NoContent();
    }

    if (users.Count(x => x.Email == user.Email) != 0) {
        return Results.BadRequest("ich will nicht mehr ich kann nicht mehr ich halte das alles nicht mehr aus");
    }

    if (!user.Email.Contains("@")) {
        return Results.NoContent();
    }

    if (user.BirthDate == null) {
        return Results.NoContent();
    }
    user.Id = users.Count() + 1;

    users.Add(user);
    return Results.Ok(user);
});

app.MapGet("users/search", (HttpContext context) => {
    var name = context.Request.Query["name"];
    var user = users.Select(u => u.Name == name).ToList();

    return Results.Ok(users);
});

app.MapGet("/users/filter", (HttpContext context) => {
    var name = context.Request.Query["name"];
    var email = context.Request.Query["email"];
    var age = context.Request.Query["age"];
    var verification = context.Request.Query["isVerified"];
    var minFollowers = context.Request.Query["minFollowers"];

    var result = users.AsQueryable();

    if (!string.IsNullOrEmpty(name)) {
        result = result.Where(u => u.Name == name);
    }

    if (!string.IsNullOrEmpty(email)) {
        result = result.Where(result => result.Email == email);
    }

    if (!string.IsNullOrEmpty(verification)) {
        if (!bool.TryParse(verification, out bool isVerified)) {
            return Results.BadRequest();
        }

        result = result.Where(n => n.IsVerified == isVerified);
    }

    if (!string.IsNullOrEmpty(minFollowers)) {
        if (!int.TryParse(minFollowers, out int followers)) {
            return Results.BadRequest();
        }

        result = result.Where(n => n.FollowerCount >= followers);
    }

    return Results.Ok(result.ToList());
});

app.MapDelete("users/delete", ([FromBody] User user) => {
    if (18 > (user.BirthDate.Year - DateTime.Now.Year)) {
        return Results.BadRequest("User zu jung zum Löschen, bitte den Service unter 133 Kontaktieren");
    }
    users.Remove(user);

    return Results.Ok();
});

app.MapGet("users/list", ([FromBody] User user, HttpContext context) => {
    var name = context.Request.Query["name"];
    var order = context.Request.Query["order"];
    var page = context.Request.Query["page"];
    var pageSize = context.Request.Query["pageSize"];

    var result = users.AsQueryable();

    var stichedQuery = $"{name}_{order}".ToLower();

    Dictionary<string, Func<IQueryable<User>>> fuctionDict = new() {
        ["name_asc"] = () => result.OrderBy(u => u.Name),
        ["name_desc"] = () => result.OrderByDescending(u => u.Name),
        ["birthdate_asc"] = () => result.OrderBy(u => u.BirthDate),
        ["birthdate_desc"] = () => result.OrderByDescending(u => u.BirthDate)
    };

    result = fuctionDict[stichedQuery]();

    if (!int.TryParse(pageSize, out int cleanPageSize)) {
        return Results.Problem();
    }

    if (!int.TryParse(page, out int cleanPage)) {
        return Results.Problem();
    }

    result = result.Skip(cleanPageSize * (cleanPage - 1)).Take(cleanPageSize);

    return Results.Ok(result);
});

app.MapGet("users/names", () => {
    return Results.Ok(users.Select(n => n.Name).ToList());
});

app.MapGet("app/allVerifiedUsers", () => {
    return Results.Ok(users.Where(n => n.IsVerified).Count());
});

app.MapGet("app/followerCount", () => {
    var result = users.Sum(n => n.FollowerCount);
});
app.Run();