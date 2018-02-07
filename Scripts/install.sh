#!/bin/bash

echo "Downloading Unity"
curl --retry 5 -o Unity.pkg https://netstorage.unity3d.com/unity/fc1d3344e6ea/MacEditorInstaller/Unity-2017.3.1f1.pkg

echo "Installing Unity"
sudo installer -dumplog -package Unity.pkg -target /
