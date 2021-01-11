#!/bin/bash

if ! doxygen -v &> /dev/null; then

    echo "Installing doxygen"

    brew update
    brew install doxygen
    brew cleanup

else

    echo "Skipping installation of doxygen"

fi
