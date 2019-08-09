build:
	Scripts/install_pandoc.sh
	Scripts/build_docs.sh
	Scripts/build_package.sh

test: SHELL:=/bin/bash
test:
	bash <(curl -fsSL https://raw.githubusercontent.com/neogeek/unity-ci-tools/master/bin/test.sh)

clean:
	rm -rf build/
	rm -rf Library/
	rm -rf Packages/
	rm -rf ProjectSettings/
	rm -f test.xml
	rm -f unity.log

deploy:
	git subtree push --prefix Assets/Plugins/CandyCoded origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/Plugins/CandyCoded master`:upm --force
