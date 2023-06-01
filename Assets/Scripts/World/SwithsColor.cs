using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithsColor : MonoBehaviour
{
    //public int idType, idColor;

    public Color[] ColorFirst, ColorSecond;

    public MeshRenderer[] meshRenderers;
    public ColorGraund[] colorGraunds;

    public bool isSecond;

    public void ColorPanel(int idType, int idColor)
    {
        if(idType == 0)
        {
            if (isSecond)
            {
                colorGraunds[0].stokColor = ColorFirst[idColor];
                colorGraunds[1].stokColor = ColorSecond[idColor];
                colorGraunds[2].stokColor = ColorFirst[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorFirst[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorSecond[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorFirst[idColor];
            }
            else
            {
                colorGraunds[0].stokColor = ColorSecond[idColor];
                colorGraunds[1].stokColor = ColorFirst[idColor];
                colorGraunds[2].stokColor = ColorSecond[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorSecond[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorFirst[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorSecond[idColor];
            }
        }

        if (idType == 1)
        {
            if (isSecond)
            {
                colorGraunds[0].stokColor = ColorFirst[idColor];
                colorGraunds[1].stokColor = ColorFirst[idColor];
                colorGraunds[2].stokColor = ColorSecond[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorFirst[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorFirst[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorSecond[idColor];
            }
            else
            {
                colorGraunds[0].stokColor = ColorSecond[idColor];
                colorGraunds[1].stokColor = ColorSecond[idColor];
                colorGraunds[2].stokColor = ColorFirst[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorSecond[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorSecond[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorFirst[idColor];
            }
        }

        if (idType == 2)
        {
            if (isSecond)
            {
                colorGraunds[0].stokColor = ColorFirst[idColor];
                colorGraunds[1].stokColor = ColorSecond[idColor];
                colorGraunds[2].stokColor = ColorSecond[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorFirst[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorSecond[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorSecond[idColor];
            }
            else
            {
                colorGraunds[0].stokColor = ColorSecond[idColor];
                colorGraunds[1].stokColor = ColorFirst[idColor];
                colorGraunds[2].stokColor = ColorFirst[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorSecond[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorFirst[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorFirst[idColor];
            }
        }

        if (idType == 3)
        {
            if (isSecond)
            {
                colorGraunds[0].stokColor = ColorFirst[idColor];
                colorGraunds[1].stokColor = ColorFirst[idColor];
                colorGraunds[2].stokColor = ColorFirst[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorFirst[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorFirst[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorFirst[idColor];
            }
            else
            {
                colorGraunds[0].stokColor = ColorSecond[idColor];
                colorGraunds[1].stokColor = ColorSecond[idColor];
                colorGraunds[2].stokColor = ColorSecond[idColor];

                if (!(colorGraunds[0].colorPlayer == meshRenderers[0].material.color)) meshRenderers[0].material.color = ColorSecond[idColor];
                if (!(colorGraunds[1].colorPlayer == meshRenderers[1].material.color)) meshRenderers[1].material.color = ColorSecond[idColor];
                if (!(colorGraunds[2].colorPlayer == meshRenderers[2].material.color)) meshRenderers[2].material.color = ColorSecond[idColor];
            }
        }
    }
}
