using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    CharacterController characterController;

    [Header("Movimiento")]
    [SerializeField] public float velocidad = 8.0f;
    [SerializeField] public float velocidadGiro = 360.0f;
    public TiposMovimientosPlatformer tipoMovimiento = TiposMovimientosPlatformer.ambos;
    private Vector3 moveDirection = Vector3.zero;

    public Vector3 posicionSpawn = new Vector3(10f, 0f, 10f);

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.position = posicionSpawn;
    }

    void Update()
    {
        switch (tipoMovimiento)
        {
            case TiposMovimientosPlatformer.horizontal:
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
                break;
            case TiposMovimientosPlatformer.vertical:
                moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
                break;
            case TiposMovimientosPlatformer.ambos:
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                break;
        }

        // Normalize moveDirection if not zero to prevent faster diagonal movement
        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection.Normalize();
        }

        moveDirection *= velocidad;

        // Movimiento
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotacion
        if (moveDirection != Vector3.zero)
        {
            Vector3 targetPosition = transform.position + moveDirection;
            targetPosition.y = transform.position.y;
            Vector3 positionDelta = targetPosition - transform.position;
            Quaternion q = Quaternion.LookRotation(positionDelta);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, velocidadGiro * Time.deltaTime);
        }
    }

    public enum TiposMovimientosPlatformer
    {
        horizontal,
        vertical,
        ambos
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
