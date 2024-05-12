using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Transform mano;
    [SerializeField] private bool henoRecogido = false;
    [SerializeField] private bool lecheRecogida = false;

    public Transform Mano { get => mano;}
    public bool HenoRecogido { get => henoRecogido; set => henoRecogido = value; }
    public bool LecheRecogida { get => lecheRecogida; set => lecheRecogida = value; }
    

    private void Start()
    {
        mano = gameObject.transform.GetChild(1).GetChild(0);
    }
        
    
}
