var builder = WebApplication.CreateBuilder(args); var app = builder.Build();
var tasks = new List<TaskItem> { new(1, "Documentar API", false), new(2, "Preparar demo", true) }; var nextId = 3;
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/tasks", () => Results.Ok(tasks));
app.MapPost("/tasks", (NewTask input) => { if (string.IsNullOrWhiteSpace(input.Title)) return Results.BadRequest(new { error = "title es obligatorio" }); var task = new TaskItem(nextId++, input.Title.Trim(), false); tasks.Add(task); return Results.Created($"/tasks/{task.Id}", task); });
app.MapPatch("/tasks/{id:int}", (int id) => { var index = tasks.FindIndex(t => t.Id == id); if (index < 0) return Results.NotFound(); tasks[index] = tasks[index] with { Done = !tasks[index].Done }; return Results.Ok(tasks[index]); });
app.Run("http://localhost:5080");
record TaskItem(int Id, string Title, bool Done); record NewTask(string Title);
