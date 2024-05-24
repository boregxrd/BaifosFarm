using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraneroInicio : MonoBehaviour
{
    Animator animatorGranero;

    void Awake()
    {
        animatorGranero = GetComponentInChildren<Animator>();
    }

    public void activarGallo() {
        if(animatorGranero != null) animatorGranero.SetTrigger("cocoroco");
        else Debug.Log("AAAAA");
    }
}
