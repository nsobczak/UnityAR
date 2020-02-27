# UnityAR

AR Android application: use real weather data to interact with 3D assets. Assets are linked to markers: nintendo 3ds AR cards.

Download apk [here](https://github.com/nsobczak/UnityAR/releases).

## Features
- wind speed changes rotation speed of 3D assets
- add object to a marker, you choose the object and the marker
- click on object to move its marker relative location
- click on object to delete it
- use phone location to get current weather
- virtually change real location to change weather
- change virtual light for virtual assets to better to match daylight

## Requirements
- Android 4.1 (API level 16).
- Internet connection to retrieve weather data.
- Geolocation is optional, you can manually add your location.

## Project uses
- [unity 2018 lts](https://unity3d.com/get-unity/download/archive)
- [vuforia version 8.3.8](https://developer.vuforia.com/)
- [weather api](https://openweathermap.org/api)
- [nintendo 3ds ar cards](https://www.nintendo.com/3ds/ar-cards/), 6 cards included in media folder
- [SimpleJSON](http://wiki.unity3d.com/index.php/SimpleJSON)
- [3D assets](https://sketchfab.com/trucverte)

## TODO

- use wind direction to change rotation direction
- use temperature data
- use rain data to add some particle on screen
