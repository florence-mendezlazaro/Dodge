using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("ObstacleProperties")]
    [SerializeField] private float obstacle_speed = 5f;

    [Header("OtherGameVariables")]
    [SerializeField] private bool point_given = false;
    private Camera cam;
    [SerializeField] private float destroy_timer = 0f;
    Player player;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        transform.position += Vector3.down * obstacle_speed * Time.deltaTime;

        if (player != null && player.transform.position.y > transform.position.y && !point_given)
        {
            FindAnyObjectByType<GameManager>().AddToScore(100);

            point_given = true;
        }

        DestroySelf();
    }

    private void DestroySelf()
    {
        Vector3 view_position = cam.WorldToViewportPoint(transform.position);

        if (view_position.x < 0 || view_position.x > 1 || view_position.y < 0 || view_position.y > 1)
        {
            destroy_timer += Time.deltaTime;

            if (destroy_timer >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}