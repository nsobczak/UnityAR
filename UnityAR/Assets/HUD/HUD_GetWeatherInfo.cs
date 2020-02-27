using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_GetWeatherInfo : MonoBehaviour
{
    #region Parameters
    [SerializeField] private GameObject weatherControllerObject;
    [SerializeField] private Text textToUse;

    protected WeatherController _weatherController;
    #endregion

    //____________________________________________________________________
    void Start()
    {
        _weatherController = weatherControllerObject.GetComponent<WeatherController>();

    }

    void Update()
    {
        textToUse.text = _weatherController.GetInfoToString();
    }
}
