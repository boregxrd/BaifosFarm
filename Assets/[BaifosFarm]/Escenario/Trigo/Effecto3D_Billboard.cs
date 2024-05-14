using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effecto3D_Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.forward, mainCamera.transform.up);
        }
    }
}
