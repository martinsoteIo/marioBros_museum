using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelected : MonoBehaviour
{
    public List<Texture> textures;
    private RawImage rawImage;
    private int index = 0;

    void Start()
    {
        rawImage = GetComponent<RawImage>(); // aprovechamos el mismo componente

        if (textures.Count > 0)
        {
            rawImage.texture = textures[index]; // imagen mostrada en la posicion 0
        }
    }

    public void NextTexture() // funcion para avanzar el indice
    {
        if (textures.Count == 0) return; // si no hay elementos
        
        index++;
        if (index >= textures.Count)
            index = 0; // si llegamos al final, volvemos al inicio

        rawImage.texture = textures[index]; // sustituye la imagen
    }

    public void PreviousTexture() // funcion para retroceder indice
    {
        if (textures.Count == 0) return; // si no hay elementos

        index--;
        if (index < 0) 
            index = textures.Count - 1; // si llegamos al inicio, vamos al final

        rawImage.texture = textures[index];  // sustituye la imagen
    }
}
