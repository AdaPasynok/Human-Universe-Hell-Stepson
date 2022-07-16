using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private AudioClip levelSong;
    [Range(0f, 1f)]
    [SerializeField] private float songVolume = 0.1f;
    [Space]
    [SerializeField] private LineView lineView;
    [SerializeField] private Image characterPortrait;
    [SerializeField] private Sprite catSprite;
    [SerializeField] private Sprite horseSprite;
    [SerializeField] private Sprite roosterSprite;
    [SerializeField] private AudioClip[] catSounds;
    [SerializeField] private AudioClip[] horseSounds;
    [SerializeField] private AudioClip[] roosterSounds;

    private AudioSource audioSource;
    private AudioClip[] soundsToPlay;

    private void Awake()
    {
        Instance = this;

        Cursor.lockState = CursorLockMode.None;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MusicManager.Instance.ChangeSong(levelSong, songVolume);
    }

    public void ContinueDialogue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lineView.OnContinueClicked();
        }
    }

    public void PlaySound()
    {
        AudioClip randomSound = soundsToPlay[Random.Range(0, soundsToPlay.Length)];

        audioSource.PlayOneShot(randomSound);
    }

    // ≈батори€ с синглтоном, чтобы можно было вызывать метод из скрипта диалога с <<portrait character>>
    [YarnCommand("portrait")]
    private static void ChangePortrait(string character)
    {
        Sprite characterSprite = null;
        Instance.characterPortrait.enabled = true;

        switch (character)
        {
            case "cat":
                characterSprite = Instance.catSprite;
                Instance.soundsToPlay = Instance.catSounds;
                break;
            case "horse":
                characterSprite = Instance.horseSprite;
                Instance.soundsToPlay = Instance.horseSounds;
                break;
            case "rooster":
                characterSprite = Instance.roosterSprite;
                Instance.soundsToPlay = Instance.roosterSounds;
                break;
            default:
                Instance.characterPortrait.enabled = false;
                break;
        }

        Instance.characterPortrait.sprite = characterSprite;
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
