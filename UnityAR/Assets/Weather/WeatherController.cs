using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * \class WindController WindController.cs
 * \brief Set wind force with WindController class, wind force change wind turbines' rotation value.
 */
public class WeatherController : MonoBehaviour
{
    #region Parameters

    [SerializeField] private Slider windSpeedSlider;
    private static float windForce;

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


    #region GetSet

    public static float WindForce
    {
        get { return windForce; }
        set { windForce = value; }
    }

    #endregion


    //____________________________________________________________________

    #region Buttons_functions

    /**
     * \fn public void UpdateWindForce()
     * \brief Change wind force value along with slider value.
     */
    public void UpdateWindForce()
    {
        windForce = windSpeedSlider.value;
    }

    #endregion
}