using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGraund : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Color stokColor, colorPlayer;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        stokColor = meshRenderer.material.color;
        //meshRenderer.material.color = new Color(1, 0, 0);
    }

    public void SetColor()
    {
        if (colorPlayer == null)
        {
            meshRenderer.material.color = new Color(0, 1, 0.4941176f);
        }
        else
        {
            meshRenderer.material.color = colorPlayer;
        }
    }

    public void RefreshColor()
    {
        meshRenderer.material.color = stokColor;
    }
}
