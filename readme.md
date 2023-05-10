# etapas
- dotnet new console -o consoleapp
- dotnet new nunit -o consoleapp.test
- dotnet new classlib -o trafego.lib

- dotnet new sln

- dotnet sln add consoleapp/consoleapp.csproj
- dotnet sln add trafego.lib/trafego.lib.csproj

- cd consoleapp
- dotnet add reference ../trafego.lib/trafego.lib.csproj

- cd ..
- cd consoleapp.test
- dotnet add reference ../trafego.lib/trafego.lib.csproj




