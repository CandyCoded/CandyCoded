#!/bin/bash

if [ ! -d "$HOME/cache" ]; then

    mkdir -m 777 "$HOME/cache"

fi

URL="https://netstorage.unity3d.com/unity/c18cef34cbcd/MacEditorInstaller/Unity-2018.2.2f1.pkg"
FILENAME=$(basename "$URL")

if [ ! -f "$HOME/cache/$FILENAME" ]; then

    echo "Downloading Unity"
    curl --retry 5 -o "$HOME/cache/$FILENAME" "$URL"

fi

echo "Installing Unity"
sudo installer -dumplog -package "$HOME/cache/$FILENAME" -target /
