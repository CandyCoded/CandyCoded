#!/bin/bash

mkdir -p Build

mv Assets/Plugins/CandyCoded/Tests Assets/Plugins/CandyCoded/Tests~
mv Assets/Plugins/CandyCoded/Tests.meta Assets/Plugins/CandyCoded/Tests~.meta

BUILD_TAG=$(git fetch && git tag | sort -V | tail -n1)

LATEST_UNITY_VERSION=$(find-unity)

echo "Building with ${LATEST_UNITY_VERSION}"

"${LATEST_UNITY_VERSION}/Contents/MacOS/Unity" \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/Plugins" \
    "$(pwd)/Build/CandyCoded-${BUILD_TAG}.unitypackage" \
    -quit

mv Assets/Plugins/CandyCoded/Tests~ Assets/Plugins/CandyCoded/Tests
mv Assets/Plugins/CandyCoded/Tests~.meta Assets/Plugins/CandyCoded/Tests.meta
