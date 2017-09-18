#!/bin/bash
echo "close dotnet service"
systemctl stop kestrel-myWorkSpace.service
echo "ready to publish"
cd ../src/MyWorkSpace.MPA
dotnet publish -c release
echo "ready to copy files"
cp bin/Release/netcoreapp2.0/publish /var/aspnetcore/myworkspace -fr
systemctl start kestrel-myWorkSpace.service
