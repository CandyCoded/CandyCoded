#!/bin/bash

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/CandyCoded" \
    "$(pwd)/CandyCoded.unitypackage" \
    -quit
