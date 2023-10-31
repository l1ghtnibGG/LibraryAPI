# LibraryAPI 

The project is developed on :  

 - .NET 6.0
 - Entity Framework Core
 - Microsoft SQL Server
 - Authentication via JwtBearer
 - Swagger UI
 - AutoMapper

# Run Locally
Clone the project

```bash
  git clone https://github.com/l1ghtnibGG/LibraryAPI.git
```

Go to the project directory

```bash
  cd LibraryAPI
```

Set your connection string to MS SQL Server in "ConnectionStrings/"LibraryAPI"" inside appsettings.json    

`"ConnectionStrings": {
    "LibraryAPI" : "Data Source=<Your Server Name>;Database=LibraryAPI;User ID='<YourUserId>';Password='<YourPassword>';Trusted_Connection=false"
  }`


Go to swagger page 

    https://localhost:7091/swagger/index.html

You can see 6 request for books and 2 for users.

### Book Controller

 - GET - Get a list of books from database
 - GET with {id} - Get a certain book by its Id
 - GET with {string} - Get a certain book by its ISBN
 - POST - Create a new book. Request body must contain a book info in JSON. JWT token required in headers for authentication
 - PUT with {id} - Update info about existing book by its Id. Request body must contain a book info in JSON. JWT token required in headers for authentication
 - DELETE with {id} - Delete a book by its Id. JWT token required in headers for authentication

### User Controller

 - POST in User/Resiter with Body - For registration.
 - POST in User/Login with Body - For authentication.

  `{
  "email": "user@example.com",
  "password": "string"
   }`

## JWT Authentication

If login successfully the server will return a Jwt Token. Copy the token.

### Authentication

1. Find the green "Authorize" button at the top of the page.
2. Click on it and insert 'Bearer' [space] and then your JWT Token in the text input below.
3. Click "Authorize".

If your token is valid, you will be able to perform Add, Edit, Delete operations.
