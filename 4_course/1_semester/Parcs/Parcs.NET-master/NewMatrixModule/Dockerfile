 
 FROM microsoft/dotnet-framework-build:4.7.1-windowsservercore-1709 AS build-env

 WORKDIR /app

 RUN mkdir C:\app\out

 COPY . .

 RUN nuget restore -PackagesDirectory ../packages

 RUN msbuild.exe MatrixGenerator/MatrixGenerator.csproj /t:Build /p:Configuration=Release /p:OutputPath=/matrix

 RUN /matrix/MatrixGenerator.exe 2000 2000 /app/out/matrix1.mtr
 RUN /matrix/MatrixGenerator.exe 2000 2000 /app/out/matrix2.mtr

 RUN msbuild.exe /t:Build /p:Configuration=Release /p:OutputPath=out

 FROM microsoft/windowsservercore:1709
 WORKDIR /app
 ENV PATH /app:$PATH
 COPY --from=build-env /app/out .

 ENTRYPOINT ["NewMatrixModule.exe", "--m1", "matrix1.mtr", "--m2", "matrix2.mtr"]
