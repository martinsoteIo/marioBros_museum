using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    [SerializeField] private Light targetLight;
    [SerializeField] private KeyCode toggleKey = KeyCode.F; // cambia F por la tecla que quieras

    public void Toggle() // puedes enlazarlo a un botón UI
    {
        if (targetLight != null) targetLight.enabled = !targetLight.enabled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) Toggle();
    }
}