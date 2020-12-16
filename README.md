# DayzPosConv

This small utility was made to ease the conversion of the coordinates of map objects between various formats created by mods.  
Conversions can be made back and forth.  

![DayZPosConv_iQRvKaZdaq](https://user-images.githubusercontent.com/5454586/87328904-e04cdf80-c53e-11ea-92a4-05def2d645cc.png)
As for example, you can use this tool for restoring the "COM Scene" from TraderObjects.txt (Trader mod) and modifying it in COM.  

### Supported formats
  - COM Export for DayZ Expansion (.map files)  
  Example: `Land_FuelStation_Build|1234 567 890|0 0 0`  
  - COM Export for spawning objects inside of mission (init.c)  
  Example: `SpawnObject( "Land_FuelStation_Build", "1234 567 890", "0 0 0" );`  
  - TraderObjects.txt  
  Used by Trader mod to spawn map objects.  
  - COM Scene (JSON file).  
  The scene that you can load and edit in Community Offline Mode.  
  Scene file can be found under server profile directory.  
  The name either is `latest.json` for Expansion Mod COM **OR** `COMObjectEditorSave.json` for Vanilla COM.  
  - DayZ Editor Scene (*.dze JSON file)  
  The scene that you can load and edit in [DayZ Editor](https://github.com/InclementDab/DayZ-Editor).  
  Note: Make sure to check if `MapName` property matches with the map you're working with.

### Usage
Clone and build it yourself or get a [binary release](https://github.com/virtyvoid/DayZPosConv/releases).  

--  
  Licensed under MIT. Comes without support & warranties.