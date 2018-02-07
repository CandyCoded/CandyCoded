test:
	UNITYCI_PROJECT_NAME=CandyCoded Scripts/test.sh

install:
	Scripts/install.sh

clean:
	rm -rf CandyCoded/Temp
	rm test.xml
	rm unity.log
