﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using System.Globalization;

[System.Serializable]
public struct GPSCoordinate
{
    [SerializeField]
    private float _latitude;
    [SerializeField]
    private float _longitude;

    public GPSCoordinate(float a, float b)
    {
        _latitude = a;
        _longitude = b;
    }

    public float Latitude
    {
        get { return _latitude; }
        set { _latitude = value; }
    }

    public float Longitude
    {
        get { return _longitude; }
        set { _longitude = value; }
    }
}

public class WeatherController : MonoBehaviour
{
    #region Parameters

    //[SerializeField] private Slider windSpeedSlider;
    //private static float windForce;

    //public string url = "http://api.openweathermap.org/data/2.5/weather?lat=50.633&lon=3.0586&APPID=814446a83d7a9fe9a23361c2a67eeea9";
    [SerializeField] private string APPID = "&APPID=814446a83d7a9fe9a23361c2a67eeea9";

    public string city;
    public string weatherDescription;
    public float temp;
    public float tempMin;
    public float tempMax;
    public int pressure;
    public int humidity;
    public float windSpeed;
    public int windDeg;
    public int clouds;

    public bool bUseManuallySetGPSCoordValues = true;
    [SerializeField] private GPSCoordinate manualCoord = new GPSCoordinate(50.633f, 3.0586f);
    [SerializeField] private GPSCoordinate currentCoord;
    #endregion

    //____________________________________________________________________

    #region singleton

    private static WeatherController windControllerInstance = null;


    /**
    * \fn private WindController()
    * \brief Change wind force value along with slider value.
    */
    private WeatherController()
    {
    }


    /**
    * \fn public static WindController GetWindControllerInstance()
    * \brief access WindController instance
    */
    public static WeatherController GetWindControllerInstance
    {
        get
        {
            if (windControllerInstance == null)
                windControllerInstance = new WeatherController();
            return windControllerInstance;
        }
    }

    #endregion

    //____________________________________________________________________

    IEnumerator GetCoordinates()
    {
        //while true so this function keeps running once started.
        while (true)
        {
            // check if user has location service enabled
            if (!Input.location.isEnabledByUser)
                yield break;

            // Start service before querying location
            Input.location.Start(1f, .1f);

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(0.5f);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                Debug.Log("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
                yield break;
            }
            else
            {
                // Access granted and location value could be retrieved
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

                ////if original value has not yet been set save coordinates of player on app start
                //if (bUseManualValues)
                //{
                //    manualCoord.Latitude = Input.location.lastData.latitude;
                //    manualCoord.Longitude = Input.location.lastData.longitude;
                //    bUseManualValues = false;
                //}

                //overwrite current lat and lon everytime
                currentCoord.Latitude = Input.location.lastData.latitude;
                currentCoord.Longitude = Input.location.lastData.longitude;
            }
            Input.location.Stop();
        }
    }


    IEnumerator Start()
    {
        //get gps coord
        yield return StartCoroutine("GetCoordinates");

        //go to the api
        //http://api.openweathermap.org/data/2.5/weather?lat=50.633&lon=3.0586&APPID=814446a83d7a9fe9a23361c2a67eeea9
        UnityWebRequest request = UnityWebRequest.Get("http://api.openweathermap.org/data/2.5/weather?lat="
            + (bUseManuallySetGPSCoordValues ? manualCoord.Latitude : currentCoord.Latitude) + "&lon="
            + (bUseManuallySetGPSCoordValues ? manualCoord.Longitude : currentCoord.Longitude) + APPID);
        yield return request.SendWebRequest();

        if (request.error == null || request.error == "")
        {
            SetWeatherFromJson(request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }

    }

    void SetWeatherFromJson(string jsonString)
    {
        Debug.Log("parsing " + jsonString);
        var weatherJson = JSON.Parse(jsonString);
        city = weatherJson["name"].Value;
        weatherDescription = weatherJson["weather"][0]["description"].Value;
        //temp = weatherJson["main"]["temp"].AsFloat; //doesn't work => why? simplejson broken?
        temp = float.Parse(weatherJson["main"]["temp"].Value, CultureInfo.InvariantCulture);
        tempMin = float.Parse(weatherJson["main"]["temp_min"].Value, CultureInfo.InvariantCulture);
        tempMax = float.Parse(weatherJson["main"]["temp_max"].Value, CultureInfo.InvariantCulture);
        pressure = weatherJson["main"]["pressure"].AsInt;
        humidity = weatherJson["main"]["humidity"].AsInt;
        clouds = weatherJson["clouds"]["all"].AsInt;
        windSpeed = float.Parse(weatherJson["wind"]["speed"].Value, CultureInfo.InvariantCulture);
        windDeg = weatherJson["wind"]["deg"].AsInt;
    }

    //____________________________________________________________________

    //#region Buttons_functions

    ///**
    // * \fn public void UpdateWindForce()
    // * \brief Change wind force value along with slider value.
    // */
    //public void UpdateWindForce()
    //{
    //    windForce = windSpeedSlider.value;
    //}

    //#endregion
}
