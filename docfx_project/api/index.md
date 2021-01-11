# ![CandyCoded](/images/logo.png)

> Custom Unity Components that are delightful

[![Build Status](https://travis-ci.org/CandyCoded/CandyCoded.svg?branch=master)](https://travis-ci.org/CandyCoded/CandyCoded)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/b0c24c2b49e2430b9ce42e2ba07e83ee)](https://www.codacy.com/app/CandyCoded/CandyCoded?utm_source=github.com&utm_medium=referral&utm_content=CandyCoded/CandyCoded&utm_campaign=Badge_Grade)
[![Join the chat at https://discord.gg/nNtFsfd](https://img.shields.io/badge/discord-join%20chat-7289DA.svg)](https://discord.gg/nNtFsfd)
[![npm](https://img.shields.io/npm/v/xyz.candycoded.candycoded)](https://www.npmjs.com/package/xyz.candycoded.candycoded)
[![license](https://img.shields.io/npm/l/xyz.candycoded.candycoded)](https://github.com/CandyCoded/CandyCoded/blob/master/LICENSE)

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
- SaveManager methods
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
    "xyz.candycoded.candycoded": "https://github.com/CandyCoded/CandyCoded.git#v4.1.0",
    ...
  }
}
```

#### Scoped UPM Registry

```json
{
  "dependencies": {
    "xyz.candycoded.candycoded": "4.1.0",
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
