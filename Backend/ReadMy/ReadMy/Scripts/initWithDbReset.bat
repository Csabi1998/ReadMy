docker rm --force SqlServer

docker run -e "ACCEPT_EULA=Y" --name SqlServer -e "SA_PASSWORD=MyPass@word" -p 1436:1433 -d mcr.microsoft.com/mssql/server:2019-latest
timeout /t 10
docker exec -it SqlServer /opt/mssql-tools/bin/sqlcmd -S localhost,1436 -U sa -P "MyPass@word" -Q "CREATE DATABASE [ReadMyDadabase]"


set ReadMyService=C:\Users\Levi\Documents\GitHub\ReadMy\Backend\ReadMy\ReadMy

start cmd /K "dotnet run --project %ReadMyService%"