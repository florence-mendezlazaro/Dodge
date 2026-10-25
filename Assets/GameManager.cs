using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("DefaultUI")]
    [SerializeField] private GameObject default_ui;
    [SerializeField] private Button pause_button;

    [Header("PauseMenu")]
    [SerializeField] private GameObject pause_menu;
    [SerializeField] private Button resume_button;
    [SerializeField] private Button quit_button;

    [Header("GameScene Variables")]
    private bool is_paused = false;

    private void Awake()
    {
        Time.timeScale = 1f;

        default_ui.SetActive(true);
        pause_button.onClick.AddListener(() => GamePaused());

        pause_menu.SetActive(false);
        resume_button.onClick.AddListener(() => GamePaused());
        quit_button.onClick.AddListener(() => Debug.Log("Transition To Main Menu"));
    }

    private void GamePaused()
    {
        if (is_paused)
        {
            pause_menu.SetActive(false);
            default_ui.SetActive(true);
            
            is_paused = false;

            Time.timeScale = 1f;
        }
        else
        {
            pause_menu.SetActive(true);
            default_ui.SetActive(false);

            is_paused = true;

            Time.timeScale = 0f;
        }
    }
}