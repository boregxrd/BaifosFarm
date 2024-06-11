
using UnityEngine;
using UnityEngine.UI;

public class TextoDinero : MonoBehaviour
{
    [SerializeField] Text dineroTexto;

    ContadorDinero contadorDinero;

    private void Start()
    {
        contadorDinero = FindObjectOfType<ContadorDinero>();
        dineroTexto.text = contadorDinero.Dinero.ToString();
    }
}
