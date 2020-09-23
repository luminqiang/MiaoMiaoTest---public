#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiaoMiaoTest.WebApi/MiaoMiaoTest.WebApi.csproj", "MiaoMiaoTest.WebApi/"]
COPY ["MiaoMiaoTest.Services/MiaoMiaoTest.Services.csproj", "MiaoMiaoTest.Services/"]
COPY ["MiaoMiaoTest.Common/MiaoMiaoTest.Common.csproj", "MiaoMiaoTest.Common/"]
COPY ["MiaoMiaoTest.FrameWork/MiaoMiaoTest.FrameWork.csproj", "MiaoMiaoTest.FrameWork/"]
COPY ["MiaoMiaoTest.Spider/MiaoMiaoTest.Spider.csproj", "MiaoMiaoTest.Spider/"]
COPY ["MiaoMiaoTest.Config/MiaoMiaoTest.Config.csproj", "MiaoMiaoTest.Config/"]
COPY ["MiaoMiaoTest.Models/MiaoMiaoTest.Models.csproj", "MiaoMiaoTest.Models/"]
COPY ["MiaoMiaoTest.Repository/MiaoMiaoTest.Repository.csproj", "MiaoMiaoTest.Repository/"]
COPY ["MiaoMiaoTest.Application/MiaoMiaoTest.Application.csproj", "MiaoMiaoTest.Application/"]
RUN dotnet restore "MiaoMiaoTest.WebApi/MiaoMiaoTest.WebApi.csproj"
COPY . .
WORKDIR "/src/MiaoMiaoTest.WebApi"
RUN dotnet build "MiaoMiaoTest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiaoMiaoTest.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiaoMiaoTest.WebApi.dll"]