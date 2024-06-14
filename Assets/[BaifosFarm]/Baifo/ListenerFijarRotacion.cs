using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerFijarRotacion : MonoBehaviour
{
    [SerializeField] Transform baifoPos;
    void Update()
    {
        Vector3 posicionCamara = Camera.main.transform.position;
        Vector3 direccionCamara = posicionCamara - transform.position;
        direccionCamara.y = 0;
        direccionCamara = -direccionCamara;
        transform.rotation = Quaternion.LookRotation(direccionCamara);
        transform.position = baifoPos.position;
    }
}
