using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


/**
 * \class ControlButtonPanel ControlButtonPanel.cs
 * \brief ControlButtonPanel class is used to show or hide left buttons panel.
 */
public class ControlButtonPanel : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject ShowPanelController;
    [SerializeField] private GameObject HidePanelController;
    [SerializeField] private GameObject PanelToControl;

    #endregion


    //____________________________________________________________________

    #region Buttons_functions

    /**
     * \fn public void ShowPanelButtonClicked()
     * \brief Show left bttons panel on clicked.
     */
    public void ShowPanelButtonClicked()
    {
        ShowPanelController.SetActive(false);
        HidePanelController.SetActive(true);
        PanelToControl.SetActive(true);
    }


    /**
     * \fn public void ShowPanelButtonClicked()
     * \brief Hide left bttons panel on clicked.
     */
    public void HidePanelButtonClicked()
    {
        ShowPanelController.SetActive(true);
        HidePanelController.SetActive(false);
        PanelToControl.SetActive(false);
    }

    #endregion
}