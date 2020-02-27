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
    [SerializeField] private String tagImageTarget = "ImageTarget";
    [SerializeField] private Text imageTargetName;
    [SerializeField] private GameObject[] prefabs;

    private int _objToSpawnIdx;

    private GameObject[] _images;
    private int _imageIdx;
    #endregion


    //____________________________________________________________________

    void Start()
    {
        _objToSpawnIdx = 0;
        UpdateNameObjToSpawn();

        _images = GameObject.FindGameObjectsWithTag(tagImageTarget);
        _imageIdx = 0;
        UpdateNameImageTarget();
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

    public void UpdateNameImageTarget()
    {
        imageTargetName.text = _images[_imageIdx].name;
    }

    public void SwitchImageIdx(bool increment = true)
    {
        _imageIdx += (increment ? 1 : -1);
        if (_imageIdx <= 0)
            _imageIdx = _images.Length - 1;
        else if (_imageIdx >= _images.Length)
            _imageIdx = 0;

        UpdateNameImageTarget();
    }

    public void AddObjectButtonClicked()
    {
        GameObject obj = prefabs[_objToSpawnIdx];
        Debug.Log("spawned obj: " + obj);

        if (null != obj)
        {
            Transform trans = obj.GetComponent<Transform>();
            GameObject currentObj = Instantiate(obj, Vector3.zero, trans.rotation);
            currentObj.transform.SetParent(_images[_imageIdx].transform);
            currentObj.transform.localPosition = trans.position;
            currentObj.transform.localRotation = trans.rotation;
            currentObj.transform.localScale = trans.localScale;
            Debug.Log("pos = " + currentObj.transform.position.ToString() +
                " | rotation = " + currentObj.transform.rotation.ToString() +
               " | localscale = " + currentObj.transform.localScale.ToString() +
                " | lossyscale = " + currentObj.transform.lossyScale.ToString());

            currentObj.tag = tagClickable;
            //ObjControl.objList.Add(obj);
        }
        else
            Debug.Log("obj is null");
    }
    #endregion
}
