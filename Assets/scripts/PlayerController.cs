//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = false;
    private bool isDead = false;
    public float speed = 0;
    private float MoveX;
    private float MoveY;
    private float JumpPower;
    private Rigidbody rb;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Input System function called once you do Move action
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        MoveX = movementVector.x;
        MoveY = movementVector.y;
    }

    // Check if is in collision with something
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "base" || collision.gameObject.name == "lavaPlane")
        {
            Debug.Log("Game Over");
            isDead = true;
            text.SetActive(true);
        }
    }

    // Input System function called once you do Jump action
    void OnJump(InputValue movementValue)
    {
        if (!isGrounded) return;
        Vector3 jump = new Vector3(0f, 4f, 0f);

        if (!isDead)
            rb.AddForce(jump, ForceMode.Impulse);
    }

    // Update Player position
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-MoveX, JumpPower, -MoveY);

        if (!isDead)
            rb.AddForce(movement * speed, ForceMode.Force);
        isGrounded = false;
    }

}
