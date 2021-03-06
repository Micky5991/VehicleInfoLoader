# Vehicle Information Library Loader V1.4.2
This library utilizes the [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo) and provides a simple way to get information about vehicles in GTA V

## Installation
### Requirements
* [Newtonsoft.JSON 10.0.3](https://www.nuget.org/packages/Newtonsoft.Json/10.0.3) *(Already supplied by GT-MP)*
* [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)

### Steps
1. Install the latest version of the VehicleInfoLoader from [NuGet](https://www.nuget.org/packages/VehicleInfoLoader)
2. Copy the dll of this package to your **resource's root-folder**.
3. Add the assembly to your meta.xml `<assembly ref="VehicleInfoLoader.dll" />`
4. Get the [appropiate .ZIP of Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)
5. Unpack the full zip file in the subfolder **vehicleinfo** of your serer.

## Documentation
[WIKI](https://github.com/Micky5991/VehicleInfoLoader/wiki)

## Changelog
### V1.4.2
* Added `VehicleManifest.ValidMods()`
* Made loading of vehicle-manifest data thread-safe
* Added check to VehicleModType.Mod() if specified mod in modtype exists. (Fixes #2)
* **Changed return-type of VehicleModType.Mods() to `IReadOnlyDictionary<string, VehicleMod>`**

### V1.4.1
* Added VehicleModType.Mods()

### V1.4.0
* Renamed `VehicleInfo` to `VehicleInfoLoader`
* Released package on [NuGet](https://www.nuget.org/packages/VehicleInfoLoader)

### V1.3.1
* Updated depenencies of all referenced packages

### V1.3.0
* Added support for vehicleInfo.json 1.4.0


## Todo
-

## License
MIT License

Copyright (c) 2017 Francesco Paolocci

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
