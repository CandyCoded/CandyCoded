test:
	Scripts/test.sh

install:
	Scripts/install.sh

build:
	Scripts/build.sh

clean:
	rm -rf Library/
	rm -rf ProjectSettings/
	rm -rf UnityPackageManager/
	rm test.xml
	rm unity.log
