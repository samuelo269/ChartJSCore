dotnet clean
dotnet build
C:\Users\samue\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe -target:"C:\Users\samue\.nuget\packages\nunit.consolerunner\3.16.3\tools\nunit3-console.exe" -targetargs:"D:\C#\ChartJSCore\src\ChartJSCoreTest\bin\Debug\net7.0\ChartJSCoreTest.dll --result:D:\C#\ChartJSCore\src\ChartJSCoreTest\TestResults\results.xml" -output:"D:\C#\ChartJSCore\src\ChartJSCoreTest\TestResults\CodeCoverage.xml" -register:user
reportgenerator -reports:"D:\C#\ChartJSCore\src\ChartJSCoreTest\TestResults\CodeCoverage.xml" -targetdir:"D:\C#\ChartJSCore\src\ChartJSCoreTest\TestResults\CoverageReport"
start "D:\C#\ChartJSCore\src\ChartJSCoreTest\TestResults\CoverageReport\index.htm"
