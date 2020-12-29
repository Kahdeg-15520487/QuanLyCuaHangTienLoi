SETLOCAL
cd QuanLyCuaHangTienLoi.Data
dotnet tool install --global dotnet-ef
dotnet ef database drop
dotnet ef database update