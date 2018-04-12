test:
	Scripts/test.sh

install:
	Scripts/install.sh

build:
	Scripts/build.sh

docs-tools:
	brew install pandoc
	brew cask install basictex

docs:
	rm -rf Assets/Plugins/CandyCoded/Documentation/
	Scripts/build_docs.sh

clean:
	rm -rf Library/
	rm -rf ProjectSettings/
	rm -rf UnityPackageManager/
	rm test.xml
	rm unity.log
