using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   
    private Vector2 input;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    
    private void Move(Vector2 input)
    {
        this.input = input;
    }


    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.OnJump += Jump;
    }

    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnJump -= Jump;
    }






    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2 (input.x,0);
        rb.position += velocity * speed * Time.fixedDeltaTime;
    }
}
