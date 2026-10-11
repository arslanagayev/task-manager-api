# Task Manager API

A small REST API for creating and listing tasks, built with **ASP.NET Core (.NET 8)** and documented with **Swagger / OpenAPI**. It was my first ASP.NET Core project: the goal was to learn how controllers, routing, model binding and validation fit together.

## Endpoints

| Method | Route | What it does | Responses |
|---|---|---|---|
| `GET` | `/api/tasks` | Returns every task | `200 OK` with a JSON array |
| `POST` | `/api/tasks` | Creates a task and assigns the next id | `201 Created` with the task, or `400 Bad Request` when the title is empty |

A task looks like this:

```json
{ "id": 1, "title": "Write the README", "isCompleted": false }
```

## Run it

You need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
dotnet run --launch-profile http
```

Then open <http://localhost:5106/swagger> to try the endpoints in the browser, or send the ready-made requests in [`TaskManagerAPI.http`](TaskManagerAPI.http) from Visual Studio, Rider or VS Code.

## How it works

```
Program.cs                    registers controllers and Swagger, maps routes
Controllers/TasksController   GET and POST /api/tasks, validates the title
Models/TaskItem               id, title, isCompleted
```

Tasks live in an in-memory list inside the controller, so they reset every time the app restarts. There is no database yet on purpose: this project focuses on the HTTP layer.

## What I would add next

- Persistence with Entity Framework Core and SQLite
- `GET`, `PUT` and `DELETE` for a single task (`/api/tasks/{id}`)
- A service layer with dependency injection instead of a static list
- Integration tests with `WebApplicationFactory`

## License

[MIT](LICENSE)
