using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorearObjeto : MonoBehaviour
{
    private int indexHijo = 0;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Transform hijo = transform.GetChild(indexHijo);
        rend = hijo.GetComponent<Renderer>();
        StartCoroutine(CambiarColorCadaSegundo());
    }
    IEnumerator CambiarColorCadaSegundo()
    {
        while (true)
        {
            if (rend != null)
            {
                Color nuevoColor = new Color(Random.value, Random.value, Random.value);
                rend.material.color = nuevoColor;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
