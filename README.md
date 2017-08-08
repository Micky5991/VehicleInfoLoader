# Vehicle Information Library Loader V1.1.0
This library utilizes the [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo) and provides a simple way to get information about vehicles in GTA V

## Installation
### Requirements
* [Newtonsoft.JSON 10.0.2](https://www.nuget.org/packages/Newtonsoft.Json/10.0.2) *(Already supplied by GT-MP)*
* [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)

### Steps
1. Download the [latest version of the VehicleInfo.dll](https://github.com/Micky5991/VehicleInfoLoader/releases/latest) 
2. Copy the downloaded DLL into *your resource's folder*.
3. Add the assembly to your meta.xml `<assembly ref="VehicleInfo.dll" />`
4. Get the [appropiate .ZIP of Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)
5. Unpack the full zip file in the subfolder **vehicleinfo** of your serer.
6. Add a reference to that VehicleInfo.dll in your Project --> [Tutorial for VisualStudio](https://msdn.microsoft.com/en-us/library/wkze6zky.aspx)

## Documentation
[WIKI](https://github.com/Micky5991/VehicleInfoLoader/wiki)

## Changelog

### V1.2.0
* Updated to match VehicleInfo V1.3.0

### V1.1.0
* Added asynchronous methods to get a vehiclemanifest-object (+ extension)

### V1.0.1
* Added Get by NetHandle method

### V1.0.0
* Initial release

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
