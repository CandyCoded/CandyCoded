# Changelog

## v1.0.0-beta.11 (October 21, 2018)

### Bug Fixes

- Prevent attempt to select color when no color exists. <https://github.com/neogeek/CandyCoded/pull/44>
- Fixed issue with ObservableList RemoveRange method <https://github.com/neogeek/CandyCoded/pull/56>

### Features

- Wrap Vector3 in Quaternion.Euler method call. <https://github.com/neogeek/CandyCoded/pull/45>
- Added GetLayerMask extension. <https://github.com/neogeek/CandyCoded/pull/49>
- Added LoadAssetBundle <https://github.com/neogeek/CandyCoded/pull/40>
- Added InputManager <https://github.com/neogeek/CandyCoded/pull/48>
- Added Permutations method. <https://github.com/neogeek/CandyCoded/pull/52>
- Added RaycastHit to GetInputDown methods. <https://github.com/neogeek/CandyCoded/pull/53>
- Return item on RemoveEvent. <https://github.com/neogeek/CandyCoded/pull/54>

### Maintenance

- Removed all materials, shaders and textures. <https://github.com/neogeek/CandyCoded/pull/38>
- Switch to remote Travis CI scripts <https://github.com/neogeek/CandyCoded/pull/41>
- Removed camera components in favor of Cinemachine. <https://github.com/neogeek/CandyCoded/pull/42>
- Test the routine value before calling StopCoroutine. <https://github.com/neogeek/CandyCoded/pull/46>

## v1.0.0-beta.10 (August 9, 2018)

### Bug Fixes

- Put event handler call after the list is modified. <https://github.com/neogeek/CandyCoded/pull/33>

### Features

- Added ToList method to ObservableList. <https://github.com/neogeek/CandyCoded/pull/34>
- Added RotateTo that takes quaternion rather than Vector3. <https://github.com/neogeek/CandyCoded/pull/32>

### Maintenance

- Improved code quality per recommendations via [Codacy](https://www.codacy.com/) and [Sonar C#](https://github.com/SonarSource/sonar-csharp)

## v1.0.0-beta.9 (July 16, 2018)

### Bug Fixes

- Fixed invalid rotation reference. <https://github.com/neogeek/CandyCoded/pull/31>

## v1.0.0-beta.8 (July 16, 2018)

### Features

- Added DisplayInInspector IEnumerator support <https://github.com/neogeek/CandyCoded/pull/28>

### Bug Fixes

- Fixed issue with animation rotation <https://github.com/neogeek/CandyCoded/pull/30>

## v1.0.0-beta.7 (July 12, 2018)

### Features

- Added Transform.GetChildrenByName method.
- Added ObservableList object.

### Maintenance

- Improved code quality per recommendations via [Codacy](https://www.codacy.com/) and [Sonar C#](https://github.com/SonarSource/sonar-csharp)

## v1.0.0-beta.6 (June 24, 2018)

### Bug Fixes

- Fixed issue where a field was missing from the inspector in a ScriptableObject.

## v1.0.0-beta.5 (June 17, 2018)

### Features

- Added billboard component <https://github.com/neogeek/CandyCoded/pull/23>
- Added Update and Reset events to CustomGenericScriptableObject. <https://github.com/neogeek/CandyCoded/pull/22>
- Added `Version.txt` to documentation folder.

### Maintenance

- Improved code quality per recommendations via [Codacy](https://www.codacy.com/) and [Sonar C#](https://github.com/SonarSource/sonar-csharp)

## v1.0.0-beta.4 (June 8, 2018)

### Features

- Added Runner OneShot method <https://github.com/neogeek/CandyCoded/pull/21>
- Added relative end position toggle to line Gizmo component <https://github.com/neogeek/CandyCoded/pull/20>
- Object pool reference <https://github.com/neogeek/CandyCoded/pull/19>

### Bug Fixes

- Fix camera follow 3d position <https://github.com/neogeek/CandyCoded/pull/18>

## v1.0.0-beta.3 (April 15, 2018)

### Features

- Plugin documentaion <https://github.com/neogeek/CandyCoded/pull/17>

### Bug Fixes

- Changed variable name to prevent inherited member warning. <https://github.com/neogeek/CandyCoded/pull/16>

## v1.0.0-beta.2 (March 25, 2018)

### Features

- Added Clone method to Vector3AnimationCurve.
- Added Slice and Splice custom extensions to List objects
- Added new overload method for Animation.RotateTo that takes quaternions.
- Added EditKeyframeValue method.

### Bug Fixes

- Fixed bug where bounds were incorrect when not starting at Vector3.zero <https://github.com/neogeek/CandyCoded/commit/3b6e860f43d580d4f6d20289d52a06dfa22fdc7b>

## v1.0.0-beta.1 (March 12, 2018)

- Initial beta release.
