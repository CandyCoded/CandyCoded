# ![CandyCoded](logo.png)

> Custom Unity Components that are delightful

[![Build Status](https://travis-ci.org/neogeek/CandyCoded.svg?branch=master)](https://travis-ci.org/neogeek/CandyCoded)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/b0c24c2b49e2430b9ce42e2ba07e83ee)](https://www.codacy.com/app/neogeek/CandyCoded?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=neogeek/CandyCoded&amp;utm_campaign=Badge_Grade)
[![Join the chat at https://discord.gg/nNtFsfd](https://img.shields.io/badge/discord-join%20chat-7289DA.svg)](https://discord.gg/nNtFsfd)
[![](https://img.shields.io/badge/Trello-Board-blue.svg)](https://trello.com/b/LH4DWRKk/candycoded)

## Introduction

CandyCoded is a collection of useful components and extensions for building in Unity. Whether you are building a quick prototype or a production-ready experience, CandyCoded will help you get there.

## Features

- ObservableList object
- Vector2, Vector3 and Vector4 AnimationCurves objects
- CameraFollow 2D and 3D components
- ScreenShake component
- Transform animation methods
- Raycast reflect method
- Custom ScriptableObjects with event handlers
- DisplayInInspector method attribute
- EnumMask enum attribute

## Installation

### Unity Asset Store

<https://assetstore.unity.com/packages/tools/animation/candycoded-115239>

### Direct Install

[Download Latest `CandyCoded.unitypackage`](https://github.com/neogeek/CandyCoded/releases)

### Unity Package Manager _(Unity 2018)_

<https://docs.unity3d.com/Packages/com.unity.package-manager-ui@1.9/manual/index.html>

#### Install

```bash
$ git submodule add git@github.com:neogeek/CandyCoded.git Packages/CandyCoded/
```

After cloning repo with submodule already installed

```bash
$ git submodule init && git submodule update --remote
```

#### Update

```bash
$ git submodule update --remote
```

## Contents

- [Introduction](Documentation/Introduction.md)
- [Getting Started](Documentation/Getting%20Started.md)
- [Objects](Documentation/1.%20Objects/)
    - [ObservableList](Documentation/1.%20Objects/ObservableList.md)
        - [Count](Documentation/1.%20Objects/ObservableList.md#count)
        - [IsReadOnly](Documentation/1.%20Objects/ObservableList.md#isreadonly)
        - [Add](Documentation/1.%20Objects/ObservableList.md#add)
        - [Clear](Documentation/1.%20Objects/ObservableList.md#clear)
        - [Contains](Documentation/1.%20Objects/ObservableList.md#contains)
        - [CopyTo](Documentation/1.%20Objects/ObservableList.md#copyto)
        - [IndexOf](Documentation/1.%20Objects/ObservableList.md#indexof)
        - [Insert](Documentation/1.%20Objects/ObservableList.md#insert)
        - [Remove](Documentation/1.%20Objects/ObservableList.md#remove)
        - [RemoveAt](Documentation/1.%20Objects/ObservableList.md#removeat)
        - [GetRange](Documentation/1.%20Objects/ObservableList.md#getrange)
        - [AddRange](Documentation/1.%20Objects/ObservableList.md#addrange)
        - [RemoveRange](Documentation/1.%20Objects/ObservableList.md#removerange)
        - [Shuffle](Documentation/1.%20Objects/ObservableList.md#shuffle)
        - [Slice](Documentation/1.%20Objects/ObservableList.md#slice)
        - [Splice](Documentation/1.%20Objects/ObservableList.md#splice)
    - [Vector3AnimationCurve](Documentation/1.%20Objects/Vector3AnimationCurve.md)
        - [EditKeyframeValue](Documentation/1.%20Objects/Vector3AnimationCurve.md#editkeyframevalue)
        - [IsLooping](Documentation/1.%20Objects/Vector3AnimationCurve.md#islooping)
        - [MaxTime](Documentation/1.%20Objects/Vector3AnimationCurve.md#maxtime)
- [Components](Documentation/2.%20Components/)
    - [BillboardTowardsCamera](Documentation/2.%20Components/BillboardTowardsCamera.md)
    - [CameraFollow2D](Documentation/2.%20Components/CameraFollow2D.md)
    - [CameraFollow3D](Documentation/2.%20Components/CameraFollow3D.md)
    - [Gizmo](Documentation/2.%20Components/Gizmo.md)
    - [ScreenShake](Documentation/2.%20Components/ScreenShake.md)
    - [SelfDestructParticleSystem](Documentation/2.%20Components/SelfDestructParticleSystem.md)
- [Custom Extensions](Documentation/3.%20Custom%20Extensions/)
    - [AnimationCurve](Documentation/3.%20Custom%20Extensions/AnimationCurve.md)
        - [EditKeyframeValue](Documentation/3.%20Custom%20Extensions/AnimationCurve.md#editkeyframevalue)
        - [IsLooping](Documentation/3.%20Custom%20Extensions/AnimationCurve.md#islooping)
        - [MaxTime](Documentation/3.%20Custom%20Extensions/AnimationCurve.md#maxtime)
    - [GameObject](Documentation/3.%20Custom%20Extensions/GameObject.md)
        - [AddOrGetComponent](Documentation/3.%20Custom%20Extensions/GameObject.md#addorgetcomponent)
    - [Int](Documentation/3.%20Custom%20Extensions/Int.md)
        - [Contains](Documentation/3.%20Custom%20Extensions/Int.md#contains)
    - [LayerMask](Documentation/3.%20Custom%20Extensions/LayerMask.md)
        - [Contains](Documentation/3.%20Custom%20Extensions/LayerMask.md#contains)
    - [List](Documentation/3.%20Custom%20Extensions/List.md)
        - [Shuffle](Documentation/3.%20Custom%20Extensions/List.md#shuffle)
        - [Slice](Documentation/3.%20Custom%20Extensions/List.md#slice)
        - [Splice](Documentation/3.%20Custom%20Extensions/List.md#splice)
    - [Transform](Documentation/3.%20Custom%20Extensions/Transform.md)
        - [GetChildrenByName](Documentation/3.%20Custom%20Extensions/Transform.md#getchildrenbyname)
        - [LookAt2D](Documentation/3.%20Custom%20Extensions/Transform.md#lookat2d)
- [Static Methods](Documentation/4.%20Static%20Methods/)
    - [Animate](Documentation/4.%20Static%20Methods/Animate.md)
        - [Fade](Documentation/4.%20Static%20Methods/Animate.md#fade)
        - [MoveTo](Documentation/4.%20Static%20Methods/Animate.md#moveto)
        - [Position](Documentation/4.%20Static%20Methods/Animate.md#position)
        - [PositionRelative](Documentation/4.%20Static%20Methods/Animate.md#positionrelative)
        - [ScaleTo](Documentation/4.%20Static%20Methods/Animate.md#scaleto)
        - [Scale](Documentation/4.%20Static%20Methods/Animate.md#scale)
        - [ScaleRelative](Documentation/4.%20Static%20Methods/Animate.md#scalerelative)
        - [RotateTo](Documentation/4.%20Static%20Methods/Animate.md#rotateto)
        - [Rotate](Documentation/4.%20Static%20Methods/Animate.md#rotate)
        - [Stop](Documentation/4.%20Static%20Methods/Animate.md#stop)
        - [StopAll](Documentation/4.%20Static%20Methods/Animate.md#stopall)
    - [Calculation](Documentation/4.%20Static%20Methods/Calculation.md)
        - [ParentBounds](Documentation/4.%20Static%20Methods/Calculation.md#parentbounds)
    - [Debugger](Documentation/4.%20Static%20Methods/Debugger.md)
        - [DrawLines](Documentation/4.%20Static%20Methods/Debugger.md#drawlines)
    - [LoadAssetBundle](Documentation/4.%20Static%20Methods/LoadAssetBundle.md)
        - [FromUrl](Documentation/4.%20Static%20Methods/LoadAssetBundle.md#fromurl)
        - [LoadAndAddScenesFromBundle](Documentation/4.%20Static%20Methods/LoadAssetBundle.md#loadandaddscenesfrombundle)
        - [LoadAndInstantiateFromBundle](Documentation/4.%20Static%20Methods/LoadAssetBundle.md#loadandinstantiatefrombundle)
    - [Materials](Documentation/4.%20Static%20Methods/Materials.md)
        - [GetMaterialsInChildren](Documentation/4.%20Static%20Methods/Materials.md#getmaterialsinchildren)
        - [SetColorAlpha](Documentation/4.%20Static%20Methods/Materials.md#setcoloralpha)
    - [Math](Documentation/4.%20Static%20Methods/Math.md)
        - [Clerp](Documentation/4.%20Static%20Methods/Math.md#clerp)
    - [Raycast](Documentation/4.%20Static%20Methods/Raycast.md)
        - [Reflect](Documentation/4.%20Static%20Methods/Raycast.md#reflect)
    - [Runner](Documentation/4.%20Static%20Methods/Runner.md)
- [ScriptableObject](Documentation/5.%20ScriptableObject/)
    - [Bool](Documentation/5.%20ScriptableObject/Bool.md)
    - [Float](Documentation/5.%20ScriptableObject/Float.md)
    - [GameObjectList](Documentation/5.%20ScriptableObject/GameObjectList.md)
    - [Int](Documentation/5.%20ScriptableObject/Int.md)
    - [List](Documentation/5.%20ScriptableObject/List.md)
    - [ObjectPool](Documentation/5.%20ScriptableObject/ObjectPool.md)
    - [String](Documentation/5.%20ScriptableObject/String.md)
    - [CustomGenericScriptableObject](Documentation/5.%20ScriptableObject/CustomGenericScriptableObject.md)
- [Unity Editor Extensions](Documentation/6.%20Unity%20Editor%20Extensions/)
    - [CreateAssetBundles](Documentation/6.%20Unity%20Editor%20Extensions/CreateAssetBundles.md)
    - [DisplayInInspector](Documentation/6.%20Unity%20Editor%20Extensions/DisplayInInspector.md)
    - [EnumMask](Documentation/6.%20Unity%20Editor%20Extensions/EnumMask.md)

## Credits

Fonts used in logo are [**Escafina**](http://www.losttype.com/font/?name=escafina) and [**Klinic Slab**](http://www.losttype.com/font/?name=klinic), both from [**Lost Type**](http://www.losttype.com/).

