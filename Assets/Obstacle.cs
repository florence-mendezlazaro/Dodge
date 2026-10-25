using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float obstacle_speed = 5f;

    private void Update()
    {
        transform.position += Vector3.down * obstacle_speed * Time.deltaTime;
    }
}