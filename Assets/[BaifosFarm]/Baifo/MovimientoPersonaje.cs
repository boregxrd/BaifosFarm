using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    public Vector3 posicionSpawn  = new Vector3(10f, 0f, 10f);

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
            controller.Move(move.normalized * Time.deltaTime * playerSpeed);
            transform.forward = move;
        }
    }

    public bool HasMoved()
    {
        return transform.position != posicionSpawn;
    }


}
