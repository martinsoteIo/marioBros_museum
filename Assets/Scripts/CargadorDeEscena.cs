using UnityEngine;

// Esto asegura que el objeto tambien tenga un AudioSource
[RequireComponent(typeof(AudioSource))]
public class CargadorDeEscena : MonoBehaviour
{
    public string nombreEscenaACargar;
    public Vector3 coordenadasDeLlegada;

    private AudioSource sonidoDelPortal;
    private bool yaActivado = false; // Para evitar activarlo 100 veces

    void Start()
    {
        // Guardamos el componente de audio para usarlo luego
        sonidoDelPortal = GetComponent<AudioSource>();
    }

    // Esta funcion se activa cuando un Rigidbody entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si es el jugador Y no lo hemos activado ya...
        if (other.CompareTag("Player") && !yaActivado)
        {
            // 1. Marcamos como activado
            yaActivado = true;
            
            // 2. Reproducimos el sonido
            if(sonidoDelPortal != null)
            {
                sonidoDelPortal.Play();
            }
            
            // 3. Llamamos al Fader (el que hace el fundido)
            FundidoDeEscena.instancia.CargarEscenaConFundido(nombreEscenaACargar, coordenadasDeLlegada);
            
            // 4. Desactivamos el collider del trigger
            GetComponent<Collider>().enabled = false;
        }
    }
}