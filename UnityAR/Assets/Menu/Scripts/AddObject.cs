using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    #region Parameters
    [SerializeField] private String tagClickable = "ClickableObject";
    [SerializeField] private Text objToSpawnName;
    [SerializeField] private GameObject[] prefabs;

    private int _objToSpawnIdx;
    #endregion


    //____________________________________________________________________

    void Start()
    {
        _objToSpawnIdx = 0;
        UpdateNameObjToSpawn();
    }

    //____________________________________________________________________

    #region Buttons_functions

    public void UpdateNameObjToSpawn()
    {
        objToSpawnName.text = prefabs[_objToSpawnIdx].name;
    }

    public void SwitchObjToSpawn(bool increment = true)
    {
        _objToSpawnIdx += (increment ? 1 : -1);
        if (_objToSpawnIdx <= 0)
            _objToSpawnIdx = prefabs.Length - 1;
        else if (_objToSpawnIdx >= prefabs.Length)
            _objToSpawnIdx = 0;

        UpdateNameObjToSpawn();
    }

    public void AddObjectButtonClicked()
    {
        GameObject obj = prefabs[_objToSpawnIdx];
        Debug.Log("obj: " + obj);

        if (null != obj)
        {
            Transform trans = obj.GetComponent<Transform>();
            GameObject currentObj = Instantiate(obj, trans.position, trans.rotation) ;
            currentObj.tag = tagClickable;
            //ObjControl.objList.Add(obj);
        }
        else
            Debug.Log("obj is null");
    }
    #endregion
}
