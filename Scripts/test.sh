#!/bin/bash

echo "Running editor unit tests for ${UNITYCI_PROJECT_NAME}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
	-batchmode \
	-nographics \
	-silent-crashes \
	-logFile $(pwd)/unity.log \
	-projectPath "$(pwd)/${UNITYCI_PROJECT_NAME}" \
	-runEditorTests \
	-editorTestsResultFile $(pwd)/test.xml \
	-quit

rc0=$?
echo "Unit test logs"
cat $(pwd)/test.xml

if [ $rc0 -ne 0 ]; then { echo "Failed unit tests"; exit $rc0; } fi
