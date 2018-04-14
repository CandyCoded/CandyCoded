test:
	Scripts/test.sh

install:
	Scripts/install.sh

build:
	Scripts/build_docs.sh
	Scripts/build.sh

docs-tools:
	brew update
	brew cask install basictex
	brew install pandoc

docs:
	rm -rf Assets/Plugins/CandyCoded/Documentation/
	export PATH="/Library/TeX/texbin":$$PATH && Scripts/build_docs.sh

clean:
	rm -rf Library/
	rm -rf ProjectSettings/
	rm -rf UnityPackageManager/
	rm test.xml
	rm unity.log
