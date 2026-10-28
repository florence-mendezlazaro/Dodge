using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("DefaultUI")]
    [SerializeField] private GameObject default_ui;
    [SerializeField] private TextMeshProUGUI tmp_timer;
    private float timer = 0f;
    [SerializeField] private TextMeshProUGUI tmp_score;
    private int score = 0;
    [SerializeField] private Button pause_button;
    
    [Header("PauseUI")]
    [SerializeField] private GameObject pause_ui;
    [SerializeField] private Button resume_button;
    [SerializeField] private Button quit_button_one;

    [Header("GameOverUI")]
    [SerializeField] private GameObject game_over_ui;
    [SerializeField] private Button retry_button;
    [SerializeField] private Button quit_button_two;

    [Header("ObstacleSpawner")]
    [SerializeField] private Transform obstacle_spawner;
    [SerializeField] private GameObject obstacle_one;
    [SerializeField] private GameObject obstacle_two;
    [SerializeField] private GameObject obstacle_three;
    [SerializeField] private float obstacle_spawn_timer = 0f;

    [Header("OtherGameVariables")]
    [SerializeField] private bool is_paused = false;
    [SerializeField] private bool player_dead = false;

    private void Awake()
    {
        Time.timeScale = 1f;

        default_ui.SetActive(true);
        tmp_timer.text = "Time: " + timer.ToString();
        tmp_score.text = "Score: " + score.ToString();
        pause_button.onClick.AddListener(() => GamePaused());

        pause_ui.SetActive(false);
        resume_button.onClick.AddListener(() => GamePaused());
        quit_button_one.onClick.AddListener(() => Debug.Log("Transition To Main Menu!"));

        game_over_ui.SetActive(false);
        retry_button.onClick.AddListener(() => SceneManager.LoadScene(0));
        quit_button_two.onClick.AddListener(() => Debug.Log("Transition To Main Menu!"));
    }

    private void Start()
    {
        SpawnObstacle();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        tmp_timer.text = "Time: " + timer.ToString();

        obstacle_spawn_timer += Time.deltaTime;

        if (obstacle_spawn_timer >= 1.5f)
        {
            SpawnObstacle();

            obstacle_spawn_timer = 0f;
        }
    }

    private void GamePaused()
    {
        if (is_paused)
        {
            pause_ui.SetActive(false);

            default_ui.SetActive(true);

            is_paused = false;

            Time.timeScale = 1f;
        }
        else
        {
            pause_ui.SetActive(true);

            default_ui.SetActive(false);

            is_paused = true;

            Time.timeScale = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int random_number = Random.Range(0, 3);

        switch(random_number)
        {
            case 0:
                Instantiate(obstacle_one, obstacle_spawner.position, Quaternion.identity);
                break;
            
            case 1:
                Instantiate(obstacle_two, obstacle_spawner.position, Quaternion.identity);
                break;
            
            case 2:
                Instantiate(obstacle_three, obstacle_spawner.position, Quaternion.identity);
                break;
        }
    }

    private void GameOver()
    {
        if (player_dead)
        {
            Time.timeScale = 0f;

            game_over_ui.SetActive(true);

            default_ui.SetActive(false);
            pause_ui.SetActive(false);
        }
    }

    public void AddToScore(int points)
    {
        score += points;
        tmp_score.text = "Score: " + score.ToString();
    }

    public void PlayerDeathStatus(bool status)
    {
        player_dead = status;

        GameOver();
    }
}