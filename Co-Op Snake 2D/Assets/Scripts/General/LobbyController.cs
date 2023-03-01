
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button backButton;

    [SerializeField]
    private GameObject LevelSelection;
    [SerializeField]
    private Button soloButton;
    [SerializeField]
    private Button coopButton;

    private List<Button> buttons;

    private void Awake()
    {
        buttons = new List<Button>() { playButton,quitButton,backButton,soloButton,coopButton };
        buttons.ForEach(button=>button.onClick.AddListener(PlayButtonSound));
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
        backButton.onClick.AddListener(Back);
        soloButton.onClick.AddListener(SoloPlay);
        coopButton.onClick.AddListener(CoopPlay);
    }

    private void PlayButtonSound()
    {
        SoundManager.Instance.PlaySfxSound(SoundType.ButtonClick);
    }

    private void SoloPlay()
    {
        PlayerPrefs.SetInt("GameMode", (int)GameMode.Solo);
        SceneManager.LoadScene(1);
    }

    private void CoopPlay()
    {
        PlayerPrefs.SetInt("GameMode", (int)GameMode.Coop);
        SceneManager.LoadScene(2);
    }

    private void Back()
    {
        LevelSelection.SetActive(false);

    }

    private void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    private void Play()
    {
        LevelSelection.SetActive(true);
    }
}
