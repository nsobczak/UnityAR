
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    #region Parameters
    public string weatherControllerTag = "WeatherController";
    public float speed = 100.0f;
    public float  windMultiplier = 5.0f;
    [SerializeField] private Vector3 refAxe = new Vector3(0, 1, 0);
    #endregion

    //____________________________________________________________________

    private void Start()
    {
        GameObject weatherControllerGO = GameObject.FindGameObjectWithTag(weatherControllerTag);
        WeatherController wController = weatherControllerGO.GetComponent<WeatherController>();
        if (wController)
            speed = wController.windSpeed * windMultiplier;
        else
            Debug.Log("no wController found");
    }

    void Update()
    {
        //TODO: access wind force via wind controller
        //1tr/min = 6deg/sec
        transform.Rotate(refAxe * speed * Time.deltaTime);
    }
}
