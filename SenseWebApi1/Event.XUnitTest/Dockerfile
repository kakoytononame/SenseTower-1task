FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS test
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Event.XUnitTest/Event.XUnitTest.csproj", "Event.XUnitTest/"]
COPY ["SenseWebApi1/SenseWebApi1.csproj", "SenseWebApi1/"]
COPY ["SC.Internship.Common/SC.Internship.Common.csproj", "SC.Internship.Common/"]
RUN dotnet restore "Event.XUnitTest/Event.XUnitTest.csproj"
COPY . .
WORKDIR "/src/Event.XUnitTest"
RUN dotnet build "Event.XUnitTest.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Event.XUnitTest.csproj" -c Debug -o /app/publish

FROM base AS final
FROM test 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Event.XUnitTest.dll"]
