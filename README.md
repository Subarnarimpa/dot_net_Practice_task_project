# User CRUD API
A simple .NET Core Web API project with CRUD operations for a User table using Entity Framework Core and SQLite.

## Features
- Create, Read, Update, Delete users
- SQLite database
- RESTful API endpoints
- Swagger/OpenAPI documentation

## API Endpoints
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update a user
- `DELETE /api/users/{id}` - Delete a user

## Running the Application
1. Navigate to the project directory: `cd UserCrudApi`
2. Run the application: `dotnet run`
3. The API will be available at `https://localhost:7232` (or `http://localhost:5191`)

## API Documentation
When running in development mode, Swagger UI is available at:
- UI: `https://localhost:7232/swagger` (or `http://localhost:5191/swagger`)
- JSON: `https://localhost:7232/swagger/v1/swagger.json`

## Testing the API
Use the `UserCrudApi.http` file in VS Code with the REST Client extension to test the endpoints.

## Database
The application uses SQLite with Entity Framework Core. The database file `UserCrudApi.db` is created in the project directory.
