#!/bin/bash

find Documentation -name "*.md" | while read file; do
    echo "Converting ${file}"
    mkdir -p "Assets/Plugins/CandyCoded/${file%/*}"
    pandoc -V geometry:margin=1.25in "$file" -o "Assets/Plugins/CandyCoded/${file%.md}.pdf"
done
