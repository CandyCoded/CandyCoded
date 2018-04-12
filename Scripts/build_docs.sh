#!/bin/bash

find Documentation -name "*.md" | while read fname; do
    echo "Converting ${fname}"
    mkdir -p "Assets/Plugins/CandyCoded/${fname%/*}"
    pandoc -V geometry:margin=1.25in "$fname" -o "Assets/Plugins/CandyCoded/${fname%.md}.pdf"
done
