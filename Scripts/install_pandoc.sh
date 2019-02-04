#!/bin/bash

if ! pandoc -v &> /dev/null; then

    echo "Installing pandoc"

    brew update
    brew cask install basictex
    brew install pandoc
    brew cleanup

else

    echo "Skipping installation of pandoc"

fi
