using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * \class MaxRotationValue MaxRotationValue.cs
 * \brief MaxRotationValue class is used to convert and display rotation per minute.
 */
public class MaxRotationValue : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float _MAX_RPM_ = 15;

    private const float _CONVERT_RPM_DEGSEC_ = 6;
    private Slider _slider;
    private Text _rotationValue;

    #endregion


    //____________________________________________________________________

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _CONVERT_RPM_DEGSEC_ * _MAX_RPM_;

        _rotationValue = GetComponentInChildren<Text>();
    }


    void Update()
    {
        //if loop used because when value is < 0, unity only display decimal digits and we want to add <0> before
        if ((_slider.value / _CONVERT_RPM_DEGSEC_) < 1)
            _rotationValue.text = "0";
        else
            _rotationValue.text = "";
        
        //display
        _rotationValue.text += String.Format("{0:#.00} rpm", _slider.value / _CONVERT_RPM_DEGSEC_);
    }
}