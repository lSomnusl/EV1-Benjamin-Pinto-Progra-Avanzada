using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   
    //Events
    public static event System.Action<Vector2>OnPlayerMovement;
    public static event System.Action OnJump;

    [SerializeField] private PlayerInput playerinput;
    
    

    private void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "WASD":
                Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);
                break;


                case "Jump":
                if(context.started) OnJump?.Invoke();
                break;
        }
    }



    private void OnEnable()
    {
        playerinput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerinput.onActionTriggered -= HandleInput;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
