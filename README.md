# Database Intialization with Code-First design
- Database name `Template`
- Cd to the main project
- `dotnet ef migrations add Init --project ..\Data`
- `dotnet ef database update`

---

# Best Practices:

https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-2.2

- ## Background tasks https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2
- ## Bundle and minify assets https://docs.microsoft.com/en-us/aspnet/core/client-side/bundling-and-minification?view=aspnetcore-2.2&tabs=visual-studio
- ## Response compression https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-2.2
- ## Fluent Validation https://github.com/JeremySkinner/FluentValidation