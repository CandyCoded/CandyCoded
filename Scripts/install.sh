#!/bin/bash

if [ ! -d "$HOME/cache" ]; then

    mkdir -p -m 777 "$HOME/cache"

fi

URL="https://netstorage.unity3d.com/unity/fc1d3344e6ea/MacEditorInstaller/Unity-2017.3.1f1.pkg"
FILENAME=`basename "$URL"`

if [ ! -f "$HOME/cache/$FILENAME" ]; then

    echo "Downloading Unity"
    curl --retry 5 -o "$HOME/cache/$FILENAME" "$URL"

fi

echo "Installing Unity"
sudo installer -dumplog -package "$HOME/cache/$FILENAME" -target /
