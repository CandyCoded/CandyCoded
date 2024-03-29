build:
	Scripts/build_package.sh
	Scripts/build_dll.sh

test: SHELL:=/bin/bash
test:
	shellcheck Scripts/*.sh
	bash <(curl -fsSL https://raw.githubusercontent.com/neogeek/unity-ci-tools/main/bin/test.sh)

changelog:
	generate-local-changelog -u -i > CHANGELOG.md

clean:
	git clean -xdf

deploy:
	git subtree push --prefix Assets/Plugins/CandyCoded origin upm

deploy-force:
	git push origin `git subtree split --prefix Assets/Plugins/CandyCoded main`:upm --force
