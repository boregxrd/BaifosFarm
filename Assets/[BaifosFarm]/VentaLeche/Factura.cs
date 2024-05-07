using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;
    public SistemaMonetario sistemaMonetario; // Referencia al Singleton del SistemaMonetario

    private const int COSTO_CABRA = 20;
    private const int COSTO_ALIMENTAR_CABRA = 5;
    private const int COSTO_HENO_ESPECIAL = 20;

    private int numCabrasBlancas;
    private int numCabrasNegras;
    private int dineroTotal;
    public static Action OnGameOver; // Eventos estático que se disparan al cumplirse una condicion
    public static Action OnMoneyVictory;
    public static Action OnBlackGoatsVictory;

    public GameObject[] popUpsFactura; // Array para los popups en la escena de factura

    private void Awake()
    {
        cabrasNuevas = 0;
        PlayerPrefs.SetInt("HenoMejorado", 0);
        ActualizarTexto();
        //PlayerPrefs.SetInt("cabrasNegras", 0);
        // Get valores de PlayerPrefs
        numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
    }

    private void Start()
    {
        Debug.Log("cabras negras: " + numCabrasNegras);
        Debug.Log("cabras blancas: " + numCabrasBlancas);
        Debug.Log("dinero: " + dineroTotal);
        Debug.Log("Método Start iniciado");

        Debug.Log("Valor de PlayerPrefs 'TutorialCompleto': " + PlayerPrefs.GetInt("TutorialCompleto"));

        if (isGameOver())
        {
            Debug.Log("pierdes por no tener dinero para comprar cabras y no tener cabras");
            OnGameOver?.Invoke();
        }
        else if (sistemaMonetario.CalcularGastoHeno() > dineroTotal)
        {
            Debug.Log("pierdes por no tener dinero suficiente para alimentar a las cabras");
            OnGameOver?.Invoke();
        }
        else if (dineroTotal >= 200)
        {
            Debug.Log("Entra al if de victoria dinero");
            OnMoneyVictory?.Invoke();
        }
        if (PlayerPrefs.GetInt("TutorialCompleto") == 0)
        {
            Debug.Log("Iniciando corrutina ShowPopUps");
            StartCoroutine(ShowPopUps());
        }
        else
        {
            // Ocultar todos los pop-ups
            foreach (var popup in popUpsFactura)
            {
                popup.SetActive(false);
            }
            Debug.Log("Tutorial completado, pop-ups ocultos");
        }
    }

    private bool isGameOver()
    {
        if ((numCabrasBlancas + numCabrasNegras) == 0 && dineroTotal < (COSTO_CABRA + COSTO_ALIMENTAR_CABRA))
        {
            return true;
        }
        return false;
    }
    private IEnumerator ShowPopUps()
    {
        Debug.Log("Iniciando corrutina ShowPopUps");

        // Mostrar el primer popup
        popUpsFactura[0].SetActive(true);
        Debug.Log("Mostrando primer popup");

        // Crear un botón "OK" dinámicamente en el primer popup
        GameObject okButtonObject = new GameObject("OKButton");
        okButtonObject.transform.SetParent(popUpsFactura[0].transform, false);

        // Añadir componente Button
        Button okButton = okButtonObject.AddComponent<Button>();

        // Añadir RectTransform al botón
        RectTransform rectTransform = okButtonObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 50);

        // Añadir Text para mostrar "OK" en el botón
        GameObject textObject = new GameObject("ButtonText");
        textObject.transform.SetParent(okButtonObject.transform, false);

        // Añadir componente Text y establecer propiedades
        Text buttonText = textObject.AddComponent<Text>();
        buttonText.text = ">OK<";
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        buttonText.fontSize = 35; //tamaño letra
        buttonText.alignment = TextAnchor.MiddleCenter; //en el centro de pantalla
        buttonText.color = new Color(22f / 255f, 237f / 255f, 72f / 255f); // Color en formato RGB (#16ED48)
        buttonText.fontStyle = FontStyle.Bold; // Establecer el texto en negrita

        // Añadir listener al botón
        okButton.onClick.AddListener(() => {
            Destroy(okButtonObject); // Destruir el botón al hacer clic
        });

        // Esperar hasta que se destruya el botón "OK"
        while (okButtonObject != null)
        {
            yield return null;
        }

        // Ocultar el primer popup y mostrar el segundo popup
        popUpsFactura[0].SetActive(false);
        Debug.Log("Ocultando primer popup");

        popUpsFactura[1].SetActive(true);
        Debug.Log("Mostrando segundo popup");

        // Crear un botón "OK" dinámicamente en el segundo popup
        GameObject okButtonObject2 = new GameObject("OKButton2");
        okButtonObject2.transform.SetParent(popUpsFactura[1].transform, false);

        // Añadir componente Button
        Button okButton2 = okButtonObject2.AddComponent<Button>();

        // Añadir RectTransform al botón
        RectTransform rectTransform2 = okButtonObject2.AddComponent<RectTransform>();
        rectTransform2.sizeDelta = new Vector2(160, 50);

        // Añadir Text para mostrar "OK" en el botón
        GameObject textObject2 = new GameObject("ButtonText2");
        textObject2.transform.SetParent(okButtonObject2.transform, false);

        // Añadir componente Text y establecer propiedades
        Text buttonText2 = textObject2.AddComponent<Text>();
        buttonText2.text = ">OK<";
        buttonText2.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        buttonText2.fontSize = 35;
        buttonText2.alignment = TextAnchor.MiddleCenter;
        buttonText2.color = new Color(22f / 255f, 237f / 255f, 72f / 255f); // Color en formato RGB (#16ED48)
        buttonText2.fontStyle = FontStyle.Bold; // Establecer el texto en negrita

        // Añadir listener al botón
        okButton2.onClick.AddListener(() => {
            Destroy(okButtonObject2); // Destruir el botón al hacer clic
        });

        // Esperar hasta que se destruya el botón "OK" del segundo popup
        while (okButtonObject2 != null)
        {
            yield return null;
        }

        // Ocultar el segundo popup
        popUpsFactura[1].SetActive(false);
        Debug.Log("Ocultando segundo popup");

        Debug.Log("Corrutina ShowPopUps finalizada");
    }

    public void comprarCabra()
    {
        int dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        // Verificar si el jugador tiene suficiente dinero para comprar una cabra y si tiene menos de 20 cabras (20 es el limite)
        //tambien si tiene suficiente dinero para comprar heno para el siguiente dia
        if (dineroTotal >= COSTO_CABRA && numCabrasBlancas+numCabrasNegras < 20 && dineroTotal - COSTO_CABRA >= (sistemaMonetario.CalcularGastoHeno() + SistemaMonetario.PRECIO_HENO_POR_CABRA))
        {
            // Restar el costo de la cabra del dinero total
            sistemaMonetario.RestarDinero(COSTO_CABRA);

            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
            {
                numCabrasNegras++;
            }
            else
            {
                numCabrasBlancas++;
            }
            PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
            PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);

            cabrasNuevas++;
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar una cabra!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    public void continuar()
    {
        if (PlayerPrefs.GetInt("TutorialCompleto", 0) == 1)
        {
            SceneManager.LoadScene("Main"); // Si el tutorial está completo, volver al menú de inicio
        }
        else
        {
            SceneManager.LoadScene("Juego"); // Si el tutorial no está completo, ir al juego
            sistemaMonetario.RestarDinero(sistemaMonetario.CalcularGastoHeno());
        }
    }

    public void comprarHenoEspecial()
    {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        int dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        //Si tienes suficiente dinero, y no has comprado heno especial aun, puede comprarlo
        if (dineroTotal >= COSTO_HENO_ESPECIAL && valorHenoMejorado == 0 && dineroTotal - COSTO_HENO_ESPECIAL >= sistemaMonetario.CalcularGastoHeno()) 
        {
            sistemaMonetario.RestarDinero(COSTO_HENO_ESPECIAL);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar heno especial, o ya lo has comprado!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }   

    private void ActualizarTexto()
    {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        // Inicializar el texto con el valor de la leche vendida
        txtFactura.text = "Leche vendida - " + leches.ToString();

        // Agregar cabras compradas si hay nuevas
        if (cabrasNuevas >= 1)
        {
            txtFactura.text += "\nCabras compradas - " + cabrasNuevas.ToString();
        }

        // Agregar mensaje si se ha comprado heno especial
        if (valorHenoMejorado == 1)
        {
            txtFactura.text += "\nHeno especial comprado";
        }

        // Agregar el dinero total y el gasto de heno
        txtFactura.text += "\nDinero total - $" + PlayerPrefs.GetInt("DineroTotal", 0).ToString();
        txtFactura.text += "\nGasto heno siguiente día - $" + sistemaMonetario.CalcularGastoHeno().ToString();
    }

}
