Sophie's Armature Reset
=======================

A simple Unity editor tool for resetting the position and rotation of an
armature, assuming it's part of a model prefab.  This is useful for when you get
stuck in "bike pose" after working on animations.

[![Generic badge](https://img.shields.io/badge/Unity-2019.4.31f1-informational.svg)](https://unity3d.com/unity/whats-new/2019.4.31)
[![Generic badge](https://img.shields.io/badge/SDK-AvatarSDK3-informational.svg)](https://vrchat.com/home/download)

## Usage

**Save your scene and make a backup just in case!**

Open `Tools` > `SophieBlue` > `ArmatureReset` from the menu bar.  In the
window that comes up, drag in your avatar and then simply click `Reset!`

If it works, your avatar should now be reset to its default pose.

## Installation

There are two methods, pick **only one**:

### UnityPackage

Install the unitypackage the usual way, from the menu bar in Unity, going
to `Assets` then `Import Package` then `Custom Package...` and selecting the
file.

### VPM

You can also use [VRChat's VPM tool](https://vcc.docs.vrchat.com/vpm/cli/)!
First add my [VPM Repository](https://github.com/SophieBlueVR/vpm-repos), and
then you can simply go to your project directory and type:

```
vpm add package io.github.sophiebluevr.armaturereset
```

## License

ArmatureReset is available as-is under MIT. For more information see
[LICENSE](/LICENSE.txt).
