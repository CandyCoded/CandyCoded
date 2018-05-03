#!/bin/bash

if [ ! -d "$HOME/cache" ]; then

    mkdir -p -m 777 "$HOME/cache"

fi

echo "Installing pandoc"
make docs-tools

URL="https://download.unity3d.com/download_unity/d4d99f31acba/MacEditorInstaller/Unity-2018.1.0f2.pkg"
FILENAME=`basename "$URL"`

if [ ! -f "$HOME/cache/$FILENAME" ]; then

    echo "Downloading Unity"
    curl --retry 5 -o "$HOME/cache/$FILENAME" "$URL"

fi

echo "Installing Unity"
sudo installer -dumplog -package "$HOME/cache/$FILENAME" -target /
