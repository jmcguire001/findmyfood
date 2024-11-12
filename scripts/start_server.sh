#!/bin/bash
cd /home/ec2-user/findmyfood
dotnet restore
dotnet build -c Release
dotnet publish -c Release -o /home/ec2-user/prod
sudo systemctl start findmyfood.service
sudo systemctl start nginx
