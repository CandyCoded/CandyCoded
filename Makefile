test:
	Scripts/test.sh

install:
	Scripts/install.sh

build:
	make docs
	Scripts/build.sh

docs-tools:
	brew update
	brew cask install basictex
	brew install pandoc

docs:
	rm -rf Assets/Plugins/CandyCoded/Documentation/
	export PATH="/Library/TeX/texbin":$$PATH && Scripts/build_docs.sh
	cp Documentation/Version.txt Assets/Plugins/CandyCoded/Documentation/

clean:
	rm -rf Library/
	rm -rf Packages/
	rm -rf ProjectSettings/
	rm test.xml
	rm unity.log

.PHONY: build
