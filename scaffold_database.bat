SETLOCAL
cd QuanLyCuaHangTienLoi.Data
dotnet restore
dotnet build
dotnet tool install --global dotnet-ef
dotnet ef database drop
dotnet ef database update