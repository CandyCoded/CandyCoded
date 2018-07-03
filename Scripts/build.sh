#!/bin/bash

mkdir -p build

CURRENT_TAG=$(git describe --tags --abbrev=0)
CURRENT_TAG_HASH=$(git show-ref --hash=7 "${CURRENT_TAG}")
CURRENT_HASH=$(git rev-parse --short HEAD)

if [ "${CURRENT_TAG_HASH}" = "${CURRENT_HASH}" ]; then

    BUILD_TAG=${CURRENT_TAG}

else

    BUILD_TAG="master"

fi

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -exportPackage "Assets/Plugins" \
    "$(pwd)/build/CandyCoded-${BUILD_TAG}.unitypackage" \
    -quit
