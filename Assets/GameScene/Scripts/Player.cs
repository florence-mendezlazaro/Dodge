using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("PlayerProperties")]
    [SerializeField] private float player_speed = 5f;
    private Vector2 player_input;

    [Header("OtherGameVariables")]
    private Camera cam;
    private InputSystem_Actions input_system_actions;

    private void Awake()
    {
        cam = Camera.main;

        input_system_actions = new InputSystem_Actions();
    }

    private void Update()
    {
        Vector3 view_position = cam.WorldToViewportPoint(transform.position);

        view_position.x = Mathf.Clamp(view_position.x, 0.07f, 0.93f);
        view_position.y = Mathf.Clamp(view_position.y, 0.07f, 0.93f);

        transform.position = cam.ViewportToWorldPoint(view_position);

        Vector3 movement = new Vector3(player_input.x, player_input.y, 0f);

        transform.position += movement * player_speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);

            FindAnyObjectByType<GameManager>().PlayerDeathStatus(true);
        }
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