using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class WeatherHandler : MonoBehaviour
{
    #region Parameters
    [SerializeField] private GameObject weatherControllerObject;
    [SerializeField] private InputField latText;
    [SerializeField] private InputField lonText;

    protected WeatherController _weatherController;
    #endregion

    //____________________________________________________________________
    void Start()
    {
        _weatherController = weatherControllerObject.GetComponent<WeatherController>();
        latText.text = _weatherController.GetManualCoordinates().Latitude.ToString();
        lonText.text = _weatherController.GetManualCoordinates().Longitude.ToString();
    }

    public void UpdateManualCoordinates()
    {
        _weatherController.ManuallySetGPSCoordValues = true;
        float lat = float.Parse(latText.text.Replace(',', '.'), CultureInfo.InvariantCulture);
        float lon = float.Parse(lonText.text.Replace(',', '.'), CultureInfo.InvariantCulture);
        
        _weatherController.SetManualCoordinates(lat, lon);      
    }

    public void UsePhoneLocation()
    {
        _weatherController.ManuallySetGPSCoordValues = false;
        _weatherController.GetCoordinates();

        latText.text = _weatherController.GetCurrentCoord().Latitude.ToString();
        lonText.text = _weatherController.GetCurrentCoord().Longitude.ToString();
    }

}
