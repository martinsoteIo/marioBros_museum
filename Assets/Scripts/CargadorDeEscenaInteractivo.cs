using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // ¡Importante! Para poder interactuar

// Requiere estos componentes para funcionar
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(XRSimpleInteractable))]
public class CargadorDeEscenaInteractivo : MonoBehaviour
{
    public string nombreEscenaACargar;
    public Vector3 coordenadasDeLlegada;

    private AudioSource sonidoDelPortal;
    private bool yaActivado = false;

    void Start()
    {
        // Guardamos el componente de audio
        sonidoDelPortal = GetComponent<AudioSource>();
    }

    // !! ESTA ES LA FUNCION CLAVE !!
    // Es PUBLICA para que el boton pueda llamarla.
    public void ActivarTeletransporte()
    {
        // Si no lo hemos activado ya...
        if (!yaActivado)
        {
            // 1. Marcamos como activado
            yaActivado = true;

            // 2. Reproducimos el sonido
            if(sonidoDelPortal != null)
            {
                sonidoDelPortal.Play();
            }
            
            // 3. Llamamos al Fader (igual que antes)
            FundidoDeEscena.instancia.CargarEscenaConFundido(nombreEscenaACargar, coordenadasDeLlegada);
            
            // 4. Desactivamos la INTERACCION (no el collider)
            GetComponent<XRSimpleInteractable>().enabled = false;
        }
    }
}