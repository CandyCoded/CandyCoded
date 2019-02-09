#!/bin/bash

mkdir -p build

mv Assets/Plugins/CandyCoded/Tests Assets/Plugins/CandyCoded/Tests~

BUILD_TAG=$(cat Documentation/Version.txt)

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/Plugins" \
    "$(pwd)/build/CandyCoded-${BUILD_TAG}.unitypackage" \
    -quit

mv Assets/Plugins/CandyCoded/Tests~ Assets/Plugins/CandyCoded/Tests
