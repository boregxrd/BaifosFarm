using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MiniJuegoOrdenyar : MonoBehaviour
{
    [SerializeField] private GameObject objetoMiniJuegoOrdenyar;
    [SerializeField] private Text porcentaje;
    

    void Start()
    {
        objetoMiniJuegoOrdenyar.SetActive(false);
    }

    private void Update()
    {
        
    }
}
