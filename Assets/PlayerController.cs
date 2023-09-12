using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using FMOD;

public class PlayerController : MonoBehaviour
{
   
    private Vector2 input;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool isPaused = false;
    public GameObject pauseMenu;
    public bool isGrounded;
    public FMODUnity.StudioEventEmitter emitter;
    public FMODUnity.StudioEventEmitter jumpEmitter;
    public FMODUnity.StudioGlobalParameterTrigger globalVolumeMax;
    public FMODUnity.StudioGlobalParameterTrigger globalVolumeMid;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        globalVolumeMid.TriggerParameters();

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        globalVolumeMax.TriggerParameters();
    }



    private void Move(Vector2 input)
    {
        this.input = input;
        if(input.x > 0)
        {
            emitter.Play();
        }
        else
        {
            emitter.Stop();
        }
    }


    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        if(isGrounded == true)
        {
            jumpEmitter.Play();
        }
    }
    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.OnJump += Jump;
        InputManager.OnPause += HandlePause;
    }

    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnJump -= Jump;
        InputManager.OnPause -= HandlePause;
    }

    void HandlePause()
    {

        if (isPaused == false)
        {
            Pause();
        }
        else
        {
            Resume();
        }
       
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
