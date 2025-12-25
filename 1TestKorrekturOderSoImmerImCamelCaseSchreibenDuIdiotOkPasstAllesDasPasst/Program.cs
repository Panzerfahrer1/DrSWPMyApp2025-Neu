using Microsoft.AspNetCore.Mvc;
using System.Formats.Tar;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Post> posts = new List<Post>() {
    new Post() {Id = 0, Name = "Hans", Description = "...", Likes = 0},
    new Post() {Id = 1, Name = "Herbert", Description = "underidoderidoderiododeridoo ~ Winston Kirchil"}
};

app.MapGet("/users", () => posts);
app.MapGet("/userCount", () => posts.Count());
app.MapGet("/moreThan50", (HttpContext context) => {
    return posts.Where(n => n.Likes > 50).ToList();
});
app.MapGet("/hjknmlö", () => {
    if(posts.Count <= 0) {
        return Results.BadRequest();
    }
    return Results.Ok(posts.OrderByDescending(n => n.Likes).ThenBy(n => n.Id).ToList()[0]);
});

app.MapPost("/postUsr", ([FromBody]Post post) => {
    post.Id = posts.Count + 1;
    post.Likes = 0;

    posts.Add(post);

    return Results.Created();
});

app.Run();

public class Post() {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Likes { get; set; }
}