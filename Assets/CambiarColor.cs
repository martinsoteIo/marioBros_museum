using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public List<Color> nuevoColor;
    public GameObject obj;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = obj.GetComponent<Renderer>();
    }
    public void NuevoColor(int index) {
        if (rend != null) {
            rend.material.color = nuevoColor[index];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
