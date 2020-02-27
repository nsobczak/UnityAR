
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    #region Parameters
    public string weatherControllerTag = "WeatherController";
    public float speed = 100.0f;
    public float  windMultiplier = 10.0f;
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
        transform.Rotate(refAxe * speed * Time.deltaTime);
    }
}
