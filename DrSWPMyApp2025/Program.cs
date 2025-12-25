using DrSWPMyApp2025.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Razor.TagHelpers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapFallback(()=> Results.File(builder.Environment.ContentRootPath + "/Static/error.html", "text/html"));

app.MapGet("/", () => "Meine erste Web-API mit ASP.NET!");
app.MapGet("/about", () => Results.File(builder.Environment.ContentRootPath + "/Static/about.html", "text/html"));
app.MapGet("/time", () => "Es ist: "+ DateTime.Now.ToString("HH:mm") + " Uhr");

#region Erklärung
////HttpRequest request wird als Parameter übergeben
//app.MapGet("/params", (HttpRequest request) => {
//    var name = request.Query["name"];
//    var age = request.Query["age"];
//    var query = request.QueryString.ToString(); //?name=oasch&age=100 (Das ist die Ausgabe)

//    if(!int.TryParse(age, out int realAge) && realAge <= 0) {
//        throw new Exception("Du wappler");
//    }

//    return $"Query: {name} {age} \n{query}";
//});

//app.MapGet("/context", (HttpContext context) => {
//    var name = context.Request.Query["name"];
//    var query = context.Request.QueryString.ToString();
//    var connectionId = context.Connection.Id;

//    return $"QueryString: {query}\n connection-Id: {connectionId}";
//});

List<User> users = new List<User>();
app.MapGet("/users/{id}", (int id) => {
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is not null ? Results.Ok(user) : Results.NotFound();
});

app.MapPost("/users", (User user) => {
    if (user is not null) {
        user.Id = users.Count() + 1;
        users.Add(user);

        //Ich bekomme zurück wie der User erreichbar ist (/user/001) und das Objekt selbst
        return Results.Created($"/users/{user.Id}", user);
    }
    else {
        //TODO
        return Results.NotFound();
    }
});

app.MapPut("/users/{id}", (int id, User updateUser) => {
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is not null) {
        return Results.NotFound();
    }
    user.Name = updateUser.Name;
    return Results.Ok(user);
});

//Request Return codes:
app.MapGet("/context", (HttpContext context) => {
    var name = context.Request.Query["name"];
    var query = context.Request.QueryString.ToString();
    var connectionId = context.Connection.Id;

    //return $"QueryString: {query}\n connection-Id: {connectionId}";

    //return Results.BadRequest("Bad error");
    return Results.NotFound(new { message = "Ungültige Eingabe", code = "ERR-001" });

    //return Results.Unauthorized(...);
    //return Results.Conflict(...) Email addresse schon vorhanden zb
});
#endregion

app.MapGet("/greet", (HttpContext context) => {
    var name = context.Request.Query["name"];

    if(name.ToString() == string.Empty) {
        return "Hallo Gast!";
    }

    return $"Hallo {name}!";
});

app.MapGet("/calc", (HttpContext context) => {
    var a = context.Request.Query["a"];
    var b = context.Request.Query["b"];

    if (!int.TryParse(a, out int clearedA) || !int.TryParse(b, out int clearedB)) {
        return "Use propper numbers du wappler";
    }

    return $"Summe: {clearedA + clearedB}";
});


app.Use(async (context, next) => {
    var route = context.Request.Path;
    var time = DateTime.Now.ToString("HH:MM:ss.ffff");
    var connectionId = context.Connection.Id;
    var query = context.Request.Query;

    File.AppendAllText("log.txt", $"{time} | {connectionId} | '{route}' | '{query}' | \n");

    await next();
});

app.MapGet("/hello", () => Results.File(
    builder.Environment.ContentRootPath
    + "/Static/hello.html", "text/html"));

app.MapGet("/style", () => Results.File(builder.Environment.ContentRootPath
    + "/Static/style.html", "text/html"));

app.UseStaticFiles();
app.Run();

// 01.docx


