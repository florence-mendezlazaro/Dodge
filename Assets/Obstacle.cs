using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float obstacle_speed = 5f;

    private bool point_given = false;

    private void Update()
    {
        transform.position += Vector3.down * obstacle_speed * Time.deltaTime;

        Player player = FindAnyObjectByType<Player>();

        if (player.transform.position.y > transform.position.y && !point_given)
        {
            FindAnyObjectByType<GameManager>().AddToScore(100);

            point_given = true;
        }
    }
}