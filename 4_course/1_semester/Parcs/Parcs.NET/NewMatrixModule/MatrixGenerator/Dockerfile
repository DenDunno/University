 FROM microsoft/dotnet-framework-build:4.7.1-windowsservercore-1709 AS build-env
 WORKDIR /app
 COPY . .

 RUN nuget restore -PackagesDirectory ../packages
 RUN msbuild.exe /t:Build /p:Configuration=Release /p:OutputPath=out

 FROM microsoft/windowsservercore-1709
 WORKDIR /app
 ENV PATH /app:$PATH
 COPY --from=build-env /app/out ./
