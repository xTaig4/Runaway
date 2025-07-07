using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float jumpingPower = 2f;
    private float speed = 1f;
    private float xMovement;
    private Transform player;
    InputAction jumpAction;

    [SerializeField]private Rigidbody2D rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        player = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(player.transform.position.x + Time.deltaTime * speed, player.transform.position.y);
        if (jumpAction.IsPressed())
        {
            rb.velocity = Vector2.up * jumpingPower;
    
        }
    }

}
