#!/bin/bash

mkdir -p build

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/Plugins" \
    "$(pwd)/build/CandyCoded.unitypackage" \
    -quit
