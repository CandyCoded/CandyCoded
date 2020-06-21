#!/bin/bash

mkdir -p Build

BUILD_TAG=$(cat Documentation/Version.txt)

dotnet build CandyCoded.sln
cp Temp/bin/Debug/CandyCoded.dll "Build/CandyCoded-${BUILD_TAG}.dll"
