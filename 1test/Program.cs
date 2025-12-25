using _1test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>();

app.MapGet("/users", () => {
    return Results.Ok(users);
});

app.MapPost("/addUser", (User user) => {
    if (user == null) {
        return Results.BadRequest();
    }
    users.Add(user);

    return Results.Ok(new { message = "Object Created", ObjectName = $"{user.Name}" });
});

app.MapGet("/users/filer", (HttpContext context) => {
    var name = context.Request.Query["name"];
    var age = context.Request.Query["age"];
    var verified = context.Request.Query["isVerified"];

    var result = users.AsQueryable();

    if (!string.IsNullOrEmpty(name)) {
        result = result.Where(n => name == n.Name);
    }

    if (!string.IsNullOrEmpty(age)) {
        if (int.TryParse(age, out int realAge)) {
            result = result.Where(n => realAge == n.Age);
        }
    }

    if (!string.IsNullOrEmpty(verified)) {
        if (bool.TryParse(verified, out bool realVerified)) {
            result = result.Where(n => realVerified == n.isVerified);
        }
    }

    return result.ToList();
});

app.Run();