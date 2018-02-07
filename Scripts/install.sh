#!/bin/bash

if [ ! -d "$HOME/cache" ] ; then

    mkdir -p -m 777 "$HOME/cache"

    echo "Downloading Unity"
    curl --retry 5 -o "$HOME/cache/Unity.pkg" https://netstorage.unity3d.com/unity/fc1d3344e6ea/MacEditorInstaller/Unity-2017.3.1f1.pkg

fi

echo "Installing Unity"
sudo installer -dumplog -package "$HOME/cache/Unity.pkg" -target /
