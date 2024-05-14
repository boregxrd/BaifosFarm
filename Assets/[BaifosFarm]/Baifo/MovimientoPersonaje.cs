using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    public Vector3 posicionSpawn  = new Vector3(10f, 0f, 10f);
    public float rotationSpeed = 10f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        transform.position = posicionSpawn;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (move != Vector3.zero)
        {
            // Rotación suave
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Movimiento
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
        }
    }

    public bool HasMoved()
    {
        return transform.position != posicionSpawn;
    }

    public void PararMovimiento()
    {
        enabled = false;
    }
    public void ContinuarMovimiento()
    {
        enabled = true;
    }

}
