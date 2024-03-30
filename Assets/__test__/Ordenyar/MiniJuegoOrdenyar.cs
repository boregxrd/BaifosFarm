using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniJuegoOrdenyar : MonoBehaviour
{
    [SerializeField] private GameObject objetoMiniJuegoOrdenyar;
    [SerializeField] private GameObject canvas;
    

    void Start()
    {
        objetoMiniJuegoOrdenyar.SetActive(false);
    }

    private void Update()
    {
        
    }
}
