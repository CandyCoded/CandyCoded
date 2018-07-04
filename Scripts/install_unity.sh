#!/bin/bash

if [ ! -d "$HOME/cache" ]; then

    mkdir -m 777 "$HOME/cache"

fi

URL="https://download.unity3d.com/download_unity/9231f953d9d3/MacEditorInstaller/Unity-2017.4.1f1.pkg"
FILENAME=$(basename "$URL")

if [ ! -f "$HOME/cache/$FILENAME" ]; then

    echo "Downloading Unity"
    curl --retry 5 -o "$HOME/cache/$FILENAME" "$URL"

fi

echo "Installing Unity"
sudo installer -dumplog -package "$HOME/cache/$FILENAME" -target /
