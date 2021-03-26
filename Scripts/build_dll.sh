#!/bin/bash

mkdir -p Build

dotnet build CandyCoded.sln
cp Temp/bin/Debug/CandyCoded.dll "Build/CandyCoded.dll"
