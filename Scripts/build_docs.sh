#!/bin/bash

find Documentation -name "*.md" | while read -r file; do
    echo "Converting ${file}"
    mkdir -p "Assets/Plugins/CandyCoded/${file%/*}"
    pandoc -V geometry:margin=1in -V urlcolor=red "$file" -o "Assets/Plugins/CandyCoded/${file%.md}.pdf"
done
