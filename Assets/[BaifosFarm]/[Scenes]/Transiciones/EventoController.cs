using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoController : MonoBehaviour
{
    Transicion transicion;
    void Start()
    {
        transicion = GetComponentInParent<Transicion>();
    }
    
    void DesactivarPanel() {
        transicion.DesactivarPanel();
    }
}
