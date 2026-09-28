# CloudTaskManager.Api

API de práctica para el proyecto de aprendizaje de Azure.

## Requisitos

- .NET 8 SDK

## Ejecutar localmente

```bash
dotnet restore
dotnet run
```

Swagger:

- https://localhost:7084/swagger
- http://localhost:5084/swagger

Health check:

- https://localhost:7084/health

## Endpoints

- `GET /api/tasks`
- `GET /api/tasks/{id}`
- `POST /api/tasks`
- `PUT /api/tasks/{id}`
- `DELETE /api/tasks/{id}`

## Ejemplo POST

```json
{
  "title": "Deploy API to Azure",
  "description": "Create an App Service and publish the API.",
  "dueDate": "2026-10-01T18:00:00Z"
}
```

## Ejemplo PUT

```json
{
  "title": "Deploy API to Azure",
  "description": "Deployment completed.",
  "status": "Completed",
  "dueDate": "2026-10-01T18:00:00Z"
}
```

## Importante

En esta primera versión los datos se almacenan en memoria.

Esto es intencional: primero aprenderemos Azure App Service.
En la siguiente etapa sustituiremos el repositorio en memoria por:

- Entity Framework Core
- Azure SQL Database
- migrations
- configuración segura
- Managed Identity más adelante

## CORS

Por defecto permite el frontend local:

```text
http://localhost:5173
```

Más adelante añadiremos la URL de Azure Static Web Apps mediante configuración de Azure.
