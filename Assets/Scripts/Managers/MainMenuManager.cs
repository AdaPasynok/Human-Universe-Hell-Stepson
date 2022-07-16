using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip levelSong;
    [Range(0f, 1f)]
    [SerializeField] private float songVolume = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        MusicManager.Instance.ChangeSong(levelSong, songVolume);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToWindows()
    {
        Application.Quit();
    }
}
