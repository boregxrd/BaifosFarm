using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Transform mano;
    private bool henoRecogido = false;

    public bool HenoRecogido { get => henoRecogido; set => henoRecogido = value; }
    public Transform Mano { get => mano;}

    private void Start()
    {
        mano = gameObject.transform.GetChild(1).GetChild(0);
    }
        
    
}
