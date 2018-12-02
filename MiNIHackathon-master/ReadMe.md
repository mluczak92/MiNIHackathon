# MiNIHackathon

### Requirements
* Unity 2018.2.9f1
* Holotoolkit

### Config
Enable mouse click to simulate AirTap event:

Edit the script for CustomInputSelector (HoloToolKit):
```
#if UNITY_2017_2_OR_NEWER
spawnControllers = !XRDevice.isPresent && XRSettings.enabled && simulateHandsInEditor;
#else
spawnControllers = simulateHandsInEditor;
#endif
```
to just:
```
spawnControllers = simulateHandsInEditor;
```
Source: https://github.com/Microsoft/MixedRealityToolkit-Unity/issues/1537