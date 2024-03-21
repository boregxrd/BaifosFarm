using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    private CharacterController controller;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    //[SerializeField] private float jumpHeight = 1f;
    //[SerializeField] private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Makes the player face the direction of the move vector.
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }
}
