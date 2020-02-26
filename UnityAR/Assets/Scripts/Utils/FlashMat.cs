using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FlashMat : MonoBehaviour
{
    #region Parameters
    [SerializeField] private float frequency = 80.0f;

    private bool bIsEnable;
    private int timer;
    private Renderer objRenderer;
    private List<Material> initialMaterials;
    #endregion


    //____________________________________________________________________

    void EnableFash()
    {
        bIsEnable = true;

        List<Material> currentMat = new List<Material>();
        objRenderer.GetMaterials(currentMat);
        for (int i = 0; i < initialMaterials.Count; i++)
        {
            currentMat[i] = initialMaterials[i];
        }
    }
    void DisableFash()
    {
        bIsEnable = false;

        List<Material> currentMat = new List<Material>();
        objRenderer.GetMaterials(currentMat);
        for (int i = 0; i < initialMaterials.Count; i++)
        {
            currentMat[i].SetColor("_Color", Color.red);
        }
    }

    void Start()
    {
        Renderer objRenderer = GetComponentInParent<Renderer>();
        initialMaterials = new List<Material>();
        objRenderer.GetMaterials(initialMaterials);

    }


    void Update()
    {
    }
}