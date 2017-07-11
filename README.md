# Vehicle Information Library Loader
This library utilizes the [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo) and provides a simple way to get information about all vehicles in GTA V

## Installation
### Requirements
* [Newtonsoft.JSON 10.0.2](https://www.nuget.org/packages/Newtonsoft.Json/10.0.2) *(Already supplied by GT-MP)*
* [Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)

### Steps
1. Download the [latest version of the VehicleInfo.dll](https://github.com/Micky5991/VehicleInfoLoader/releases/latest) 
2. Put that dll into the root GT-MP-serverfolder
3. Add the assembly to your meta.xml `<assembly ref="VehicleInfo.dll" />`
4. Get the [appropiate version of Micky5991/GT-MP-vehicleInfo](https://github.com/Micky5991/GT-MP-vehicleInfo/releases)
5. Unpack the full zip file in the subfolder **vehicleinfo** of your serverfolder.
6. Add a reference to that VehicleInfo.dll in your Project --> [Tutorial for VisualStudio](https://msdn.microsoft.com/en-us/library/wkze6zky.aspx)

## Changelog

### V1.0.0
* Initial release
