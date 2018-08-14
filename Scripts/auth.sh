#!/bin/bash

/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -quit \
    -batchmode \
    -serial "$UNITY_SERIAL" \
    -username "$UNITY_USERNAME" \
    -password "$UNITY_PASSWORD" || true
