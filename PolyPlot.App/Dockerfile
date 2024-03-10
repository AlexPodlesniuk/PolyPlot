FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PolyPlot.App/PolyPlot.App.csproj", "PolyPlot.App/"]
COPY ["PolyPlot.Drawing.Console/PolyPlot.Drawing.Console.csproj", "PolyPlot.Drawing.Console/"]
COPY ["PolyPlot.Drawing/PolyPlot.Drawing.csproj", "PolyPlot.Drawing/"]
COPY ["PolyPlot.Widgets/PolyPlot.Widgets.csproj", "PolyPlot.Widgets/"]
RUN dotnet restore "PolyPlot.App/PolyPlot.App.csproj"
COPY . .
WORKDIR "/src/PolyPlot.App"
RUN dotnet build "PolyPlot.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PolyPlot.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolyPlot.App.dll"]
