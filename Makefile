build:
	Scripts/build_docs.sh
	Scripts/build_package.sh
	Scripts/build_dll.sh

install:
	Scripts/install_pandoc.sh

test: SHELL:=/bin/bash
test:
	shellcheck Scripts/*.sh
	bash <(curl -fsSL https://raw.githubusercontent.com/neogeek/unity-ci-tools/master/bin/test.sh)

docs:
	doxygen doxygen.config

clean:
	git clean -xdf

deploy:
	git subtree push --prefix Assets/Plugins/CandyCoded origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/Plugins/CandyCoded master`:upm --force
