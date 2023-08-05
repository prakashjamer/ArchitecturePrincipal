EF CORE 
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.5" />
	PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.5" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.5">
	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.5">
AUTO MAPPER 
SERILOG 
	-> Serilog.AspNetCore
		Serilog.Sinks.MSSqlServer

API -> BUSINESS -> DOMAIN (MAPPER) -> INFRA STRUCTURE 
SWAGGER 
Action Filer 
Exception Filter

Versioning 
1. URL BASED VERSIONING
2. Query parameter based  versioning 
3 Header based versioning 

-> 1 st create 2 folder and past  controllers and make route API/V1/ctname  or API/V2/ctname
-> Second approch  -> Microsoft.aspnetcore.mvc.versioning

----- JWT ------ 
Microsoft.AspNetCore.Authentication.JwtBearer 6.0.16
Microsoft.IdentityModel.Tokens 6.30.1
System.IdentityModel.Tokens.Jwt 6.30.1
Microsoft.AspNetCore.Identity.EntityFrameworkCore

Distributed Cache 
Microsoft.Extensions.Caching.StackExchangeRedis

Session  use 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(10));
app.UseSession();