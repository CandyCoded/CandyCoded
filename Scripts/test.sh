#!/bin/bash

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -batchmode \
    -nographics \
    -noUpm \
    -silent-crashes \
    -logFile "$(pwd)/unity.log" \
    -projectPath "$(pwd)/" \
    -runEditorTests \
    -editorTestsResultFile "$(pwd)/test.xml"

CODE=$?

echo $CODE
cat "$(pwd)/unity.log"

cat "$(pwd)/test.xml" && exit $CODE
