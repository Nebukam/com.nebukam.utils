![preview](https://img.shields.io/badge/preview-orange.svg)
![version 0.0.1](https://img.shields.io/badge/version-0.0.1-blue.svg)
![in development](https://img.shields.io/badge/status-in%20development-blue.svg)

# N:Utils
#### Unity Utils & Quality of life tools

N:Utils is a Unity package containing all sort of general-purposes shorthands, extensions & math utils.

### Features
N:Utils does not contains any object, and is only a large collection of methods & extensions. Lots of calls to Unity APIs are inlined to compensate for the overhead of using static methods & extensions. It heavily leverages Unity.Mathematics package.

---
## Hows

### Installation
To be used with Unity's Package Manager.

See [Unity's Package Manager : Getting Started](https://docs.unity3d.com/Manual/upm-parts.html)

---
## Dependencies
- **Unity.Mathematics 1.1.0** -- [com.unity.mathematics](https://github.com/Unity-Technologies/Unity.Mathematics)

---
## Credits

There are a lot of methods & equations found from various places around the web.
Most notably :

- **Unify Community Wiki** -- [Math3D](https://wiki.unity3d.com/index.php/3d_Math_functions)
- **Habrador** -- [Use Math to solve problems with Unity3D](https://www.habrador.com/tutorials/math/)

Special note : lots of equation inlining have been made possible through Unity DLL inspections using [ILSpy](https://github.com/icsharpcode/ILSpy).
