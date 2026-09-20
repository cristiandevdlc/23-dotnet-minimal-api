# .NET Minimal API

API de tareas con endpoints REST y validación básica.

```powershell
dotnet run
curl http://localhost:5080/tasks
curl -X POST http://localhost:5080/tasks -H "Content-Type: application/json" -d '{"title":"Preparar demo"}'
```
