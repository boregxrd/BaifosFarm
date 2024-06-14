
using UnityEngine;
using UnityEngine.UI;

public class TextoDinero : MonoBehaviour
{
    [SerializeField] Text dineroTexto;

    ContadorDinero contadorDinero;

    [SerializeField] Transicion transicion;

    private void Start()
    {
        transicion.FadeIn();
        contadorDinero = FindObjectOfType<ContadorDinero>();
        dineroTexto.text = contadorDinero.Dinero.ToString();
    }
}
