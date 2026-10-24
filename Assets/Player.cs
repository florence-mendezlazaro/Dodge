using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    private InputSystem_Actions input_system_actions;
    
    private Vector2 player_input;
    
    private float player_speed = 15f;

    private void Awake()
    {
        input_system_actions = new InputSystem_Actions();
    }

    private void FixedUpdate()
    {
        Vector3 position = new Vector3(player_input.x, player_input.y, 0f);
        transform.position += position * player_speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        input_system_actions.Enable();

        input_system_actions.Player.Move.performed += OnMove;
        input_system_actions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        input_system_actions.Player.Move.performed -= OnMove;
        input_system_actions.Player.Move.canceled -= OnMove;

        input_system_actions.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        player_input = ctx.ReadValue<Vector2>();
    }
}