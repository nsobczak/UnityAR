using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class ControlButtonPanel : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject ShowPanelController;
    [SerializeField] private GameObject HidePanelController;
    [SerializeField] private GameObject PanelToControl;

    #endregion


    //____________________________________________________________________

    #region Buttons_functions

    public void ShowPanelButtonClicked()
    {
        ShowPanelController.SetActive(false);
        HidePanelController.SetActive(true);
        PanelToControl.SetActive(true);
    }

    public void HidePanelButtonClicked()
    {
        ShowPanelController.SetActive(true);
        HidePanelController.SetActive(false);
        PanelToControl.SetActive(false);
    }

    #endregion
}