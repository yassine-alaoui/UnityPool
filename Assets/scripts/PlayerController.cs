//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private CharacterController character;
    private float MoveX;
    private float MoveY;
    private float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        MoveX = movementVector.x;
        MoveY = movementVector.y;
    }

    void OnJump(InputValue movementValue)
    {
        if (!character.isGrounded) return;
        Debug.Log("here");
        Vector3 jump = new Vector3(0f, 2f, 0f);

        rb.AddForce(jump, ForceMode.Impulse);  
    }

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (!context.started) return;
    //    if (!character.isGrounded) return;

    //    Vector3 jump = new Vector3(0f, JumpPower, 0f);

    //    rb.AddForce(jump, ForceMode.Impulse);
    //}

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-MoveX, JumpPower, -MoveY);

        rb.AddForce(movement * speed);


    }

}
