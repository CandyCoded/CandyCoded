# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

[![Join the chat at https://discord.gg/nNtFsfd](https://img.shields.io/badge/discord-join%20chat-7289DA.svg)](https://discord.gg/nNtFsfd)
[![npm](https://img.shields.io/npm/v/xyz.candycoded.candycoded)](https://www.npmjs.com/package/xyz.candycoded.candycoded)
[![License](https://img.shields.io/npm/l/xyz.candycoded.candycoded)](https://github.com/CandyCoded/CandyCoded/blob/main/LICENSE)

## Introduction

CandyCoded is a collection of useful components and extensions for building in Unity. Whether you are building a quick prototype or a production-ready experience, CandyCoded will help you get there.

## Features

- ObservableList object
- Vector2, Vector3 and Vector4 AnimationCurves objects
- Transform animation methods
- Raycast reflect method
- Custom ScriptableObjects with event handlers
- Event Profiler editor window
- EnumMask enum attribute
- InputManager methods
- [SaveManager methods](Documentation/3.%20Static%20Methods/SaveManager.md) - [Tutorial](Documentation/6.%20Tutorials/Save%20&%20Load%20ScriptableObjects/README.md)
- Screenshot methods and editor tools

## Installation

### Direct Install

[Download latest `CandyCoded.unitypackage` or `CandyCoded.dll`](https://github.com/CandyCoded/CandyCoded/releases)

### Unity Package Manager

<https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.0/manual/index.html>

#### Git

```json
{
  "dependencies": {
    "xyz.candycoded.candycoded": "https://github.com/CandyCoded/CandyCoded.git#v4.4.0",
    ...
  }
}
```

#### Scoped UPM Registry

```json
{
  "dependencies": {
    "xyz.candycoded.candycoded": "4.4.0",
    ...
  },
  "scopedRegistries": [
    {
      "name": "candycoded",
      "url": "https://registry.npmjs.com",
      "scopes": ["xyz.candycoded"]
    }
  ]
}
```

### Include tests

```json
{
  "dependencies": {
    ...
  },
  "testables": ["xyz.candycoded.candycoded"]
}
```

## Contents

- [Introduction](Documentation/Introduction.md)
- [Getting Started](Documentation/Getting%20Started.md)
- [Tutorials](Documentation/6.%20Tutorials/README.md)
  - [Save & Load ScriptableObjects](Documentation/6.%20Tutorials/Save%20&%20Load%20ScriptableObjects/README.md)
- [Objects](Documentation/1.%20Objects/)
  - [ObservableList](Documentation/1.%20Objects/ObservableList.md)
    - [Count](Documentation/1.%20Objects/ObservableList.md#count)
    - [IsReadOnly](Documentation/1.%20Objects/ObservableList.md#isreadonly)
    - [Add](Documentation/1.%20Objects/ObservableList.md#add)
    - [AddRange](Documentation/1.%20Objects/ObservableList.md#addrange)
    - [Clear](Documentation/1.%20Objects/ObservableList.md#clear)
    - [Contains](Documentation/1.%20Objects/ObservableList.md#contains)
    - [CopyTo](Documentation/1.%20Objects/ObservableList.md#copyto)
    - [GetRange](Documentation/1.%20Objects/ObservableList.md#getrange)
    - [IndexOf](Documentation/1.%20Objects/ObservableList.md#indexof)
    - [Insert](Documentation/1.%20Objects/ObservableList.md#insert)
    - [InsertRange](Documentation/1.%20Objects/ObservableList.md#insertrange)
    - [Pop](Documentation/1.%20Objects/ObservableList.md#pop)
    - [Random](Documentation/1.%20Objects/ObservableList.md#random)
    - [Remove](Documentation/1.%20Objects/ObservableList.md#remove)
    - [RemoveAt](Documentation/1.%20Objects/ObservableList.md#removeat)
    - [RemoveRange](Documentation/1.%20Objects/ObservableList.md#removerange)
    - [Shift](Documentation/1.%20Objects/ObservableList.md#shift)
    - [Shuffle](Documentation/1.%20Objects/ObservableList.md#shuffle)
    - [Slice](Documentation/1.%20Objects/ObservableList.md#slice)
    - [Splice](Documentation/1.%20Objects/ObservableList.md#splice)
    - [Unshift](Documentation/1.%20Objects/ObservableList.md#unshift)
  - [Vector3AnimationCurve](Documentation/1.%20Objects/Vector3AnimationCurve.md)
    - [EditKeyframeValue](Documentation/1.%20Objects/Vector3AnimationCurve.md#editkeyframevalue)
    - [IsLooping](Documentation/1.%20Objects/Vector3AnimationCurve.md#islooping)
    - [MaxTime](Documentation/1.%20Objects/Vector3AnimationCurve.md#maxtime)
- [Custom Extensions](Documentation/2.%20Custom%20Extensions/)
  - [AnimationCurve](Documentation/2.%20Custom%20Extensions/AnimationCurve.md)
    - [EditKeyframeValue](Documentation/2.%20Custom%20Extensions/AnimationCurve.md#editkeyframevalue)
    - [IsLooping](Documentation/2.%20Custom%20Extensions/AnimationCurve.md#islooping)
    - [MaxTime](Documentation/2.%20Custom%20Extensions/AnimationCurve.md#maxtime)
  - [Array](Documentation/2.%20Custom%20Extensions/Array.md)
    - [Random](Documentation/2.%20Custom%20Extensions/Array.md#random)
  - [Camera](Documentation/2.%20Custom%20Extensions/Camera.md)
    - [ScreenToHighPrecisionViewportPoint](Documentation/2.%20Custom%20Extensions/Camera.md#screentohighprecisionviewportpoint)
  - [Float](Documentation/2.%20Custom%20Extensions/Float.md)
    - [NearlyEqual](Documentation/2.%20Custom%20Extensions/Float.md#nearlyequal)
  - [GameObject](Documentation/2.%20Custom%20Extensions/GameObject.md)
    - [AddOrGetComponent](Documentation/2.%20Custom%20Extensions/GameObject.md#addorgetcomponent)
    - [GetLayerMask](Documentation/2.%20Custom%20Extensions/GameObject.md#getlayermask)
  - [Int](Documentation/2.%20Custom%20Extensions/Int.md)
    - [Contains](Documentation/2.%20Custom%20Extensions/Int.md#contains)
  - [LayerMask](Documentation/2.%20Custom%20Extensions/LayerMask.md)
    - [Contains](Documentation/2.%20Custom%20Extensions/LayerMask.md#contains)
  - [List](Documentation/2.%20Custom%20Extensions/List.md)
    - [Chunk](Documentation/2.%20Custom%20Extensions/List.md#chunk)
    - [Contains](Documentation/2.%20Custom%20Extensions/List.md#contains)
    - [Permutations](Documentation/2.%20Custom%20Extensions/List.md#permutations)
    - [Pop](Documentation/2.%20Custom%20Extensions/List.md#pop)
    - [Random](Documentation/2.%20Custom%20Extensions/List.md#random)
    - [Shift](Documentation/2.%20Custom%20Extensions/List.md#shift)
    - [Shuffle](Documentation/2.%20Custom%20Extensions/List.md#shuffle)
    - [Slice](Documentation/2.%20Custom%20Extensions/List.md#slice)
    - [Splice](Documentation/2.%20Custom%20Extensions/List.md#splice)
    - [Unshift](Documentation/2.%20Custom%20Extensions/List.md#unshift)
  - [Quaternion](Documentation/2.%20Custom%20Extensions/Quaternion.md)
    - [SnapRotation](Documentation/2.%20Custom%20Extensions/Quaternion.md#snaprotation)
  - [String](Documentation/2.%20Custom%20Extensions/String.md)
    - [Nicify](Documentation/2.%20Custom%20Extensions/String.md#nicify)
  - [Transform](Documentation/2.%20Custom%20Extensions/Transform.md)
    - [GetChildrenByName](Documentation/2.%20Custom%20Extensions/Transform.md#getchildrenbyname)
    - [LookAt2D](Documentation/2.%20Custom%20Extensions/Transform.md#lookat2d)
    - [RotateWithInputDelta](Documentation/2.%20Custom%20Extensions/Transform.md#rotatewithinputdelta)
  - [Vector3](Documentation/2.%20Custom%20Extensions/Vector3.md)
    - [NearlyEquals](Documentation/2.%20Custom%20Extensions/Vector3.md#nearlyequals)
- [Static Methods](Documentation/3.%20Static%20Methods/)
  - [Animate](Documentation/3.%20Static%20Methods/Animate.md)
    - [Fade](Documentation/3.%20Static%20Methods/Animate.md#fade)
    - [MoveTo](Documentation/3.%20Static%20Methods/Animate.md#moveto)
    - [Position](Documentation/3.%20Static%20Methods/Animate.md#position)
    - [PositionRelative](Documentation/3.%20Static%20Methods/Animate.md#positionrelative)
    - [RotateTo](Documentation/3.%20Static%20Methods/Animate.md#rotateto)
    - [Rotation](Documentation/3.%20Static%20Methods/Animate.md#rotation)
    - [ScaleRelative](Documentation/3.%20Static%20Methods/Animate.md#scalerelative)
    - [Scale](Documentation/3.%20Static%20Methods/Animate.md#scale)
    - [ScaleTo](Documentation/3.%20Static%20Methods/Animate.md#scaleto)
    - [Stop](Documentation/3.%20Static%20Methods/Animate.md#stop)
    - [StopAll](Documentation/3.%20Static%20Methods/Animate.md#stopall)
  - [Calculation](Documentation/3.%20Static%20Methods/Calculation.md)
    - [ParentBounds](Documentation/3.%20Static%20Methods/Calculation.md#parentbounds)
  - [Debugger](Documentation/3.%20Static%20Methods/Debugger.md)
    - [DrawLines](Documentation/3.%20Static%20Methods/Debugger.md#drawlines)
  - [InputMangager](Documentation/3.%20Static%20Methods/InputMangager.md)
    - [GetInputDown](Documentation/3.%20Static%20Methods/InputMangager.md#getinputdown)
    - [GetInputPosition](Documentation/3.%20Static%20Methods/InputMangager.md#getinputposition)
    - [GetInputUp](Documentation/3.%20Static%20Methods/InputMangager.md#getinputup)
    - [GetMouseButtonDown](Documentation/3.%20Static%20Methods/InputMangager.md#getmousebuttondown)
    - [GetMouseButtonUp](Documentation/3.%20Static%20Methods/InputMangager.md#getmousebuttonup)
    - [GetMousePosition](Documentation/3.%20Static%20Methods/InputMangager.md#getmouseposition)
    - [GetActiveTouch](Documentation/3.%20Static%20Methods/InputMangager.md#getactivetouch)
    - [GetTouchDown](Documentation/3.%20Static%20Methods/InputMangager.md#gettouchdown)
    - [GetTouchPosition](Documentation/3.%20Static%20Methods/InputMangager.md#gettouchposition)
    - [GetTouchUp](Documentation/3.%20Static%20Methods/InputMangager.md#gettouchup)
    - [RaycastToGameObject](Documentation/3.%20Static%20Methods/InputMangager.md#raycasttogameobject)
  - [Materials](Documentation/3.%20Static%20Methods/Materials.md)
    - [GetMaterialsInChildren](Documentation/3.%20Static%20Methods/Materials.md#getmaterialsinchildren)
    - [SetColorAlpha](Documentation/3.%20Static%20Methods/Materials.md#setcoloralpha)
  - [Math](Documentation/3.%20Static%20Methods/Math.md)
    - [Clerp](Documentation/3.%20Static%20Methods/Math.md#clerp)
  - [Raycast](Documentation/3.%20Static%20Methods/Raycast.md)
    - [Reflect](Documentation/3.%20Static%20Methods/Raycast.md#reflect)
  - [Runner](Documentation/3.%20Static%20Methods/Runner.md)
  - [SaveManager](Documentation/3.%20Static%20Methods/SaveManager.md)
    - [SaveData](Documentation/3.%20Static%20Methods/SaveManager.md#savedata)
    - [LoadData](Documentation/3.%20Static%20Methods/SaveManager.md#loaddata)
    - [DeleteData](Documentation/3.%20Static%20Methods/SaveManager.md#deletedata)
  - [Screenshot](Documentation/3.%20Static%20Methods/Screenshot.md)
    - [Save](Documentation/3.%20Static%20Methods/Screenshot.md#save)
    - [SaveTransparent](Documentation/3.%20Static%20Methods/Screenshot.md#savetransparent)
- [ScriptableObject](Documentation/4.%20ScriptableObject/)
  - [AudioPool](Documentation/4.%20ScriptableObject/AudioPool.md)
  - [Bool](Documentation/4.%20ScriptableObject/Bool.md)
  - [CustomGenericScriptableObject](Documentation/4.%20ScriptableObject/CustomGenericScriptableObject.md)
  - [Float](Documentation/4.%20ScriptableObject/Float.md)
  - [GameObject](Documentation/4.%20ScriptableObject/GameObject.md)
  - [GameObjectList](Documentation/4.%20ScriptableObject/GameObjectList.md)
  - [GameObjectPool](Documentation/4.%20ScriptableObject/GameObjectPool.md)
  - [Int](Documentation/4.%20ScriptableObject/Int.md)
  - [List](Documentation/4.%20ScriptableObject/List.md)
  - [Pool](Documentation/4.%20ScriptableObject/Pool.md)
  - [String](Documentation/4.%20ScriptableObject/String.md)
- [Unity Editor Extensions](Documentation/5.%20Unity%20Editor%20Extensions/)
  - [EnumMask](Documentation/5.%20Unity%20Editor%20Extensions/EnumMask.md)
  - [EventProfiler](Documentation/5.%20Unity%20Editor%20Extensions/EventProfiler.md)
  - [RangedSliderDrawer](Documentation/5.%20Unity%20Editor%20Extensions/RangedSliderDrawer.md)

## Credits

Fonts used in logo are [**Escafina**](http://www.losttype.com/font/?name=escafina) and [**Klinic Slab**](http://www.losttype.com/font/?name=klinic), both from [**Lost Type**](http://www.losttype.com/).
