using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ObjRaycast : MonoBehaviour
{
    #region Parameters

    [SerializeField] private String buttonPanelTag = "ButtonPanel";
    [SerializeField] private String clickableObjectTag = "ClickableObject";
    [SerializeField] private String buttonPanel_UILayer = "ButtonPanelUI";

    [SerializeField] private Slider XSlider;
    [SerializeField] private Slider YSlider;
    [SerializeField] private Slider ZSlider;

    [SerializeField] private GameObject menuButtonsPanel;

    [SerializeField] private Material highlightedMat;

    private ShowPanels showPanelsScript;
    private GameObject hitObj;
    private bool bIsCalibratingObj;
    private float objX, objY, objZ;

    #endregion


    //____________________________________________________________________

    #region GetSet

    public GameObject HitObj
    {
        get { return hitObj; }
        set { hitObj = value; }
    }

    public bool IsCalibratingObj
    {
        get { return bIsCalibratingObj; }
        set { bIsCalibratingObj = value; }
    }

    #endregion


    //____________________________________________________________________

    #region Methods

    private void InitializeObjPosValues(GameObject hitObject)
    {
        objX = hitObject.transform.position.x;
        objZ = hitObject.transform.position.y;
        objY = hitObject.transform.position.z;
    }

    private void UpdateObjPos(GameObject hitObject)
    {
        hitObject.transform.position = new Vector3(objX + XSlider.value,
            objZ + ZSlider.value, objY + YSlider.value);
    }

    public void ResetSliders()
    {
        XSlider.value = 0;
        YSlider.value = 0;
        ZSlider.value = 0;
    }

    public Material GetObj1stMat(GameObject hitObject)
    {
        return hitObject.GetComponent<Renderer>().material;
    }

    //Works for asset with only 1 material
    public void ChangeObjMat(GameObject hitObject, Material newMat)
    {
        hitObject.GetComponent<Renderer>().material = newMat;
        Component[] children = hitObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in children)
            child.material = newMat;
    }

    private void ObjHit(RaycastHit hit)
    {
        hitObj = hit.collider.gameObject;
        Debug.Log("Hit clickable object");
        ResetSliders();
        IsCalibratingObj = true;

        showPanelsScript.ShowObjPosRaycastPanel();
        ChangeObjMat(hitObj, highlightedMat);
        InitializeObjPosValues(hitObj);
    }

    public void DeleteButtonClicked()
    {
        Destroy(hitObj);
        //ObjControl.objList.Remove(hitObj);
        hitObj = null;
        showPanelsScript.HideObjPosRaycastPanel();
        showPanelsScript.HideObjDeletionConfirmationPanel();
    }

    #endregion


    //____________________________________________________________________

    void Start()
    {
        showPanelsScript = transform.GetComponent<ShowPanels>();
        bIsCalibratingObj = false;
        hitObj = null;
    }


    void Update()
    {
        if (!bIsCalibratingObj && (Input.touchCount > 0 || Input.GetMouseButton(0)))
        {
            Vector3 touch;
            if (Input.touchCount > 0)
            {
                touch = Input.touches[0].position;
                Input.touches.Initialize();
            }
            else
                touch = Input.mousePosition;

            Ray ray = Camera.allCameras[0].ScreenPointToRay(touch);
            RaycastHit hit;


            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = touch;

            List<RaycastResult> results = new List<RaycastResult>();
            if (EventSystem.current == null) { Debug.LogError("EventSystem.current is null"); }
            else
            {
                EventSystem.current.RaycastAll(pointerData, results);

                if (results.Count > 0 && results[0].gameObject.layer == LayerMask.NameToLayer(buttonPanel_UILayer))
                {
                    return;
                }
                else if (!menuButtonsPanel.activeSelf && Physics.Raycast(ray, out hit, Mathf.Infinity) &&
                       hit.collider.CompareTag(clickableObjectTag))
                {
                    ObjHit(hit);
                }
            }
        }

        if (bIsCalibratingObj)
            UpdateObjPos(hitObj);
    }
}