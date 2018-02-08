#!/bin/bash

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/CandyCoded" \
    -exportPackage "Assets/CandyCoded" \
    "$(pwd)/CandyCoded.unitypackage" \
    -quit
