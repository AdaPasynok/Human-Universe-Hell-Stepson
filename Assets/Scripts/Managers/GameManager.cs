using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip levelSong;
    [Range(0f, 1f)]
    [SerializeField] private float songVolume = 0.5f;
    [Space]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Transform enemiesContainer;
    [SerializeField] private Sprite[] characterSkulls;
    [SerializeField] private Image deathScreenSkull;

    public static GameManager Instance;
    public PlayerInput playerInput;
    public FirstPersonController player;

    private EventSystem eventSystem;
    private int enemiesAmount;

    private void Awake()
    {
        Instance = this;

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        eventSystem = EventSystem.current;
        enemiesAmount = enemiesContainer.childCount;
    }

    private void Start()
    {
        MusicManager.Instance.ChangeSong(levelSong, songVolume);
    }

    public void Restart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            playerInput.SwitchCurrentActionMap("UI");
        }
    }

    public void Unpause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Unpause();
        }
    }

    public void Unpause()
    {
        if (pauseScreen.activeSelf)
        {
            eventSystem.SetSelectedGameObject(pauseScreen); // Снимаем подсветку с последней нажатой кнопки
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
        }
    }

    public void ExitToWindows()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        playerInput.SwitchCurrentActionMap("Game");
        gameOverScreen.SetActive(true);
    }

    // Если все враги мертвы, то загружаем следующий уровень
    public void SubtractEnemy()
    {
        enemiesAmount--;

        if (enemiesAmount == 0)
        {
            StartCoroutine(LoadNextSceneDelayed());
        }
    }

    public void SetSkull(int index)
    {
        if (index >= characterSkulls.Length)
        {
            Debug.LogError("Non-existant skull");
            return;
        }

        deathScreenSkull.sprite = characterSkulls[index];
    }

    private IEnumerator LoadNextSceneDelayed()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
