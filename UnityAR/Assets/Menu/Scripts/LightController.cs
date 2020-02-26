using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * \class LightController LightController.cs
 * \brief LightController class is used to handle day/night mode.
 */
public class LightController : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject worldLight;
    [SerializeField] private GameObject dayIcon;
    [SerializeField] private GameObject nightIcon;

    private static bool isNightLightActivated;

    private Light light;
    private Color dayLight;
    private Color nightLight;

    #endregion


    //____________________________________________________________________

    #region Get/Set

    public static bool IsNightLightActivated
    {
        get
        {
            return isNightLightActivated;
        }

        set
        {
            isNightLightActivated = value;
        }
    }

    #endregion


    //____________________________________________________________________

    #region Buttons_functions

    /**
     * \fn public void SwitchModeButtonClicked()
     * \brief Change wind turbines' light on button clicked.
     */
    public void SwitchModeButtonClicked()
    {
        if (null != light)
        {
            if (IsNightLightActivated)
            {
                light.color = dayLight;
                light.intensity = 1;
                light.shadowStrength = 1;
                if (null != dayIcon && null != nightIcon)
                {
                    dayIcon.SetActive(true);
                    nightIcon.SetActive(false);
                }
            }
            else
            {
                light.color = nightLight;
                light.intensity = 0.25f;
                light.shadowStrength = 0.2f;
                if (null != dayIcon && null != nightIcon)
                {
                    dayIcon.SetActive(false);
                    nightIcon.SetActive(true);
                }
            }

            IsNightLightActivated = !IsNightLightActivated;
        }
        else
            Debug.LogError("Light is null");
    }

    #endregion


    //____________________________________________________________________

    private void Start()
    {
        if (null != worldLight)
            light = worldLight.GetComponent<Light>();
        else
            Debug.LogError("Light object not assigned");
        dayLight = new Color32(0xFF, 0xF4, 0xD6, 0xFF);
        nightLight = new Color32(0xD6, 0xD8, 0xFF, 0xFF);

        isNightLightActivated = false;
    }
}