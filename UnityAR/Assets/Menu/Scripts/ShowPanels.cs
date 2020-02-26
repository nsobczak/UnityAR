using UnityEngine;
using System.Collections;


/**
 * ShowPanels class is used to handle all panels display (show or hide panels).
 */
public class ShowPanels : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject weatherOptionsPanel;
    [SerializeField] private GameObject objAddPanel;
    [SerializeField] private GameObject lightOptionsPanel;
    [SerializeField] private GameObject objPosRaycastPanel;
    [SerializeField] private GameObject objDeletionConfirmationPanel;

    private ObjRaycast _objRaycast;
    private Material _objInitialMat;

    #endregion

    //____________________________________________________________________

    void Start()
    {
        _objRaycast = transform.GetComponent<ObjRaycast>();
    }


    //____________________________________________________________________

    #region Hide_functions

    public void HideWindOptionsPanel()
    {
        weatherOptionsPanel.SetActive(false);
    }


    public void HideObjAddPanel()
    {
        objAddPanel.SetActive(false);
    }


    public void HideLightOptionsPanel()
    {
        lightOptionsPanel.SetActive(false);
    }


    public void HideAllPanel()
    {
        HideObjAddPanel();
        HideLightOptionsPanel();
        HideWindOptionsPanel();
    }


    public void HideObjPosRaycastPanel()
    {
        objPosRaycastPanel.SetActive(false);
        if (null != _objRaycast.HitObj)
            _objRaycast.ChangeObjMat(_objRaycast.HitObj, _objInitialMat);
        _objRaycast.IsCalibratingObj = false;
    }


    public void HideObjDeletionConfirmationPanel()
    {
        objDeletionConfirmationPanel.SetActive(false);
        HideObjPosRaycastPanel();
    }

    #endregion


    //____________________________________________________________________

    #region Show_functions

    public void ShowWindOptionsPanel()
    {
        HideAllPanel();
        weatherOptionsPanel.SetActive(true);
    }


    public void ShowObjAddPanel()
    {
        HideAllPanel();
        objAddPanel.SetActive(true);
    }


    public void ShowLightOptionsPanel()
    {
        HideAllPanel();
        lightOptionsPanel.SetActive(true);
    }


    public void ShowObjPosRaycastPanel()
    {
        objPosRaycastPanel.SetActive(true);

        if (null != _objRaycast.HitObj)
            _objInitialMat = _objRaycast.GetObj1stMat(_objRaycast.HitObj);
    }


    public void ShowObjDeletionConfirmationPanel()
    {
        objDeletionConfirmationPanel.SetActive(true);
    }

    #endregion
}