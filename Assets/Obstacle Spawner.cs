using UnityEngine;

public class ObstacleSpanwer : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject obstacle_one;
    [SerializeField] private GameObject obstacle_two;
    [SerializeField] private GameObject obstacle_three;

    private float spawn_timer = 0f;

    private void Start()
    {
        SpawnObstacle();
    }

    private void Update()
    {
        spawn_timer += Time.deltaTime;

        if (spawn_timer >= 3f)
        {
            SpawnObstacle();

            spawn_timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int value = Random.Range(0, 3);

        if (value == 0)
        {
            Instantiate(obstacle_one, transform.position, Quaternion.identity);
        }
        else if (value == 1)
        {
            Instantiate(obstacle_two, transform.position, Quaternion.identity);
        }
        else if (value == 2)
        {
            Instantiate(obstacle_three, transform.position, Quaternion.identity);
        }
    }
}