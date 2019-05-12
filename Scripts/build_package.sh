#!/bin/bash

mkdir -p build

mv Assets/Plugins/CandyCoded/Tests Assets/Plugins/CandyCoded/Tests~

BUILD_TAG=$(cat Documentation/Version.txt)

LATEST_UNITY_VERSION=$(find /Applications/Unity -name Unity.app | sort -r | head -1)

echo "Building with ${LATEST_UNITY_VERSION}"

"${LATEST_UNITY_VERSION}/Contents/MacOS/Unity" \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/Plugins" \
    "$(pwd)/build/CandyCoded-${BUILD_TAG}.unitypackage" \
    -quit

mv Assets/Plugins/CandyCoded/Tests~ Assets/Plugins/CandyCoded/Tests
