#!/bin/bash
cd /home/ec2-user/paradisedonutcompany
dotnet restore
dotnet build -c Release
dotnet publish -c Release -o /home/ec2-user/prod
sudo systemctl start pdc.service
sudo systemctl start nginx
