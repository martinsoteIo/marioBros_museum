using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Buena practica
public class MoverAlPuntoDeLlegada : MonoBehaviour
{
    // AQUI ESTA LA NUEVA LINEA 1
    private AudioSource sonidoDeLlegada;

    void Start()
    {
        // AQUI ESTA LA NUEVA LINEA 2
        sonidoDeLlegada = GetComponent<AudioSource>();

        // Miramos el "buzon": ¿Hay una posicion guardada?
        if (GestorDeTeletransporteEscenas.tienePosicionGuardada == true)
        {
            // ¡Si! Mueve a este objeto (el XR Origin)
            // a la posicion guardada.
            this.transform.position = GestorDeTeletransporteEscenas.proximaPosicion;

            // Importante: Reseteamos la bandera
            GestorDeTeletransporteEscenas.tienePosicionGuardada = false;

            // AQUI ESTA LA NUEVA LINEA 3
            // ¡Reproduce el sonido de "salida"!
            if (sonidoDeLlegada != null)
            {
                sonidoDeLlegada.Play();
            }
        }
    }
}

