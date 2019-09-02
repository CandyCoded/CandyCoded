build:
	Scripts/build_docs.sh
	Scripts/build_package.sh

install:
	Scripts/install_pandoc.sh

test: SHELL:=/bin/bash
test:
	bash <(curl -fsSL https://raw.githubusercontent.com/neogeek/unity-ci-tools/master/bin/test.sh)

clean:
	git clean -xdf

deploy:
	git subtree push --prefix Assets/Plugins/CandyCoded origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/Plugins/CandyCoded master`:upm --force
