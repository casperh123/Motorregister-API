FROM motorregister-base AS build
WORKDIR /src

COPY ["MotorRegister.Api/MotorRegister.Api.csproj", "MotorRegister.Api/"]
RUN dotnet restore "MotorRegister.Api/MotorRegister.Api.csproj"

COPY ["MotorRegister.Api/", "MotorRegister.Api/"]

RUN dotnet publish "MotorRegister.Api/MotorRegister.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MotorRegister.Api.dll"]