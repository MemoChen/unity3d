using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEffect : MonoBehaviour {

    private Material curMaterial;
    public Shader curShader;
    public Color color;


    Material material
    {
        get
        {
            if (curMaterial == null)
            {
                curMaterial = new Material(curShader);
                curMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return curMaterial;
        }
    }
    private void Start()
    {
        if(!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
        if (!curShader&&!curShader.isSupported)
        {
            enabled = false;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material!=null)
        {
            material.SetColor("_Color", color);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
    private void OnDisable()
    {
        if (curMaterial)
            DestroyImmediate(curMaterial);
    }
}
