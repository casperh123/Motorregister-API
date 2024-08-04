FROM motorregister-base AS build
WORKDIR /src

COPY ["MotorRegister.Indexer/MotorRegister.Indexer.csproj", "MotorRegister.Indexer/"]
RUN dotnet restore "MotorRegister.Indexer/MotorRegister.Indexer.csproj"

COPY ["MotorRegister.Indexer/", "MotorRegister.Indexer/"]

RUN dotnet publish "MotorRegister.Indexer/MotorRegister.Indexer.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MotorRegister.Indexer.dll"]