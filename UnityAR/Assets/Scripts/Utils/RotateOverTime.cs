
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    #region Parameters
    //object to rotate
    public float WindForce = 100.0f;
    [SerializeField] private Vector3 RefAxe = new Vector3(0, 1, 0);
    #endregion

    //____________________________________________________________________

    void Start()
    {
        
    }

    void Update()
    {
        //TODO: access wind force via wind controller
        //1tr/min = 6deg/sec
        transform.Rotate(RefAxe * WindForce * Time.deltaTime);
    }
}
