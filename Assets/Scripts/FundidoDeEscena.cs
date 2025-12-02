using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para controlar la Imagen

public class FundidoDeEscena : MonoBehaviour
{
    // --- Singleton ---
    // Esto permite que el script sea llamado
    // desde cualquier otro script (ej: Fader.instancia.HacerAlgo())
    public static FundidoDeEscena instancia;
    // -----------------

    public Image pantallaDeFundido; // Arrastra tu "PantallaNegra" aqui
    public float tiempoDeFundido = 1.0f;

    void Awake()
    {
        // --- Configuracion del Singleton ---
        if (instancia == null)
        {
            instancia = this;
            // No destruir este objeto al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe uno, destruir este duplicado
            Destroy(gameObject);
        }
        // ---------------------------------
    }

    // --- FUNCIONES PRINCIPALES ---

    // Esta es la funcion que llamaran tus portales
    public void CargarEscenaConFundido(string nombreEscena, Vector3 coordenadas)
    {
        // Guarda los datos en el "buzon" como antes
        GestorDeTeletransporteEscenas.proximaPosicion = coordenadas;
        GestorDeTeletransporteEscenas.tienePosicionGuardada = true;

        // Inicia la corutina que hace todo el trabajo
        StartCoroutine(RutinaDeFundido(nombreEscena));
    }

    // Una "Corutina" es una funcion que puede pausarse
    IEnumerator RutinaDeFundido(string escena)
    {
        // 1. Aparecer (Fade Out)
        yield return StartCoroutine(Fundido(1.0f)); // 1.0f = opacidad al 100%

        // 2. Cargar la escena en segundo plano
        AsyncOperation operacion = SceneManager.LoadSceneAsync(escena);
        while (!operacion.isDone)
        {
            yield return null; // Espera hasta que la carga termine
        }

        // 3. Desaparecer (Fade In)
        // El script "MoverAlPuntoDeLlegada" ya habra movido al jugador
        // en su funcion Start() antes de que esto se ejecute.
        yield return StartCoroutine(Fundido(0.0f)); // 0.0f = opacidad al 0%
    }

    // Corutina que controla la opacidad (alpha)
    IEnumerator Fundido(float alphaDestino)
    {
        Color colorActual = pantallaDeFundido.color;
        float alphaActual = colorActual.a;
        float tiempoPasado = 0.0f;

        while (tiempoPasado < tiempoDeFundido)
        {
            // Interpola el valor de alpha
            float nuevoAlpha = Mathf.Lerp(alphaActual, alphaDestino, tiempoPasado / tiempoDeFundido);
            pantallaDeFundido.color = new Color(colorActual.r, colorActual.g, colorActual.b, nuevoAlpha);
            
            // Avanza el tiempo
            tiempoPasado += Time.deltaTime;
            yield return null; // Espera al siguiente frame
        }

        // Asegura el valor final
        pantallaDeFundido.color = new Color(colorActual.r, colorActual.g, colorActual.b, alphaDestino);
    }
}