using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float jumpingPower = 2f;
    private float speed = 2f;

    InputAction jumpAction;

    [SerializeField]private Rigidbody2D rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.IsPressed())
        {
            rb.velocity = Vector2.up * jumpingPower;
            Debug.Log("Jumped with power: " + jumpingPower);
        }
    }

}
