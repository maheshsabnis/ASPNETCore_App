# ASP.NET Core 2.2
#=============================================================================
ASP.NET Core Project Specifications
1. Program.cs
   1. Contains Main() method to create an Instance of WebHost class
   2. WebHost will provide hosting env. for the application with required objects using IApplicationBuilder. 
   3. This uses 'Startup' class from Startup.cs
2. Startup.cs 
   1. IConfiguration interface injected in Ctor
      1. Used to read application configurations from appsetting.json file
   2. ConfigureServices() method having IServiceCollection as input parameter
      1. Used to provide D.I. Container for the application
      2. IServiceCollection is used to register services in D.I. Container like
         1. Cookie Policy
         2. Database Context Objects
         3. Identity
            1. User only
            2. User and Roles
         4. Authroization with Role Policy
         5. CORS Policies for WEB API
         6. Custom Services Registretions
         7. MVC with its options
            1. Filters
            2. Message Formates for API
      3. IServiceCollection also provides ServiceLifeTime Enum
         1. Singleton
         2. Scoped, stateful aka session based
         3. Transient, stateless
      4. Servicelifetime methods from IServiceCollection using generic parameters like T, U where T is interface and U is class implementing T
         1. services.AddSingleton<T,U>();
         2. services.AddScoped<T,U>();
         3. services.AddTransient<T,U>();
   3. Configure() methods having IApplicationBuilder and IHostingEnvironment as input parameters  
      1. This method is used to add Middlewares in the Current Application and they will be used for Http Request
      2. Inbuild Middlewares
         1. UseAuthentication()
         2. UseStaticFiles()
         3. UseCookiePolicy()
         4. UseDatabaseErrorPage()
         5. UseDevelopmentErrorPage()
         6. Custom Middlewares
         7. UseMvc(), for MVC and API
            1. Routing
#=============================================================================
#EntityFramework Core
1. Microsoft.EntotyFrameworkCore
   1. DbContext Class
      1. Manage Db Connections
      2. Manage Table Mapping using DbSet<T> cursor
      3. Commit Transactions    
         1. SaveChanges() / SaveChangesAsync()
   2. DbSet<T>
      1. Read/Write Cursor
      2. It maps Entity Class of name T with Db Table of Name T
      3. Exposes methods for CRUD Operations
   3. ctx is an instance of DbContext and Emps is DbSet<Emp>
      1. To Read all Records in Async Mode
         1. var emps = await ctx.Emps.ToListAsync();
            1. Microsoft.EntityFrameworkCore for ToListAsync()
      2. To Add new Reocrd
         1. Create an imnstance of Emp and set its property values
         2. Add this instance in DbSet
            1. await ctx.Emps.AddAsync(<Instance>);
         3. Commit Transactions
            1. await ctx.SaveChangesAsync();
      3. To Search record based on Primary Key (P.K.)
         1. await ctx.Emps.FindAsync(P.K.);
      4. To Update Record
         1. Using Entity Properties (Recommended)
            1. Search record based on P.K.
            2. Updated its property values
            3. Commit Trsanctions
         2. Using ctx
            1. ctx.Update<Emps>.state = EntityState.Modified
            2. Commit Transaction 
      5. To Delete Record
         1. Search Record based on P.K.
         2. Pass it to Remove method of DbSet
         3. ctx.Emps.Remove(instance)
         4. Commit Transaction
2.  Microsoft.EntotyFrameworkCore.SqlServer (Mandatory)
3.  Microsoft.EntotyFrameworkCore.Tools
4.  Microsoft.EntotyFrameworkCore.Relational
5.  EF Core w.r.t. ASP.NET Core
    1.  Create class derived from DbContext and having DbContextOptions<DbContext> as ctor injected
        1.  Reads DbContext service from ASP.NET Core DI Container to Establish DB Connection.
6.  EF Core DB Migrations
    1.  dotnet ef migrations add <Migration-Name> -c <NameSpace.DbContext-Class>
        1.  Migration class that contains logic to generate Database and Tables
        2.  Snapshot C;ass containing logic for Constraints and Relations across tables based on entities
    2.  dotnet ef database update -c <NameSpace.DbContext-Class>