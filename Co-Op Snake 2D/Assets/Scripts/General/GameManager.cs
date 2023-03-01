using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode
{
    Solo,
    Coop
}
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int XBoundry;
    public int YBoundry;

    public int PlayerLostId;


    public List<PlayerController> Players;



    public FoodSpawner FoodSpawn;
    public GameObject GameOver;

    public GameObject GamePause;

    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Button resumeButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;
        if (GameOver.activeSelf)
            return;
        if (!GamePause.activeSelf)
            PauseGame();
        else
            ResumeGame();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        Players.ForEach(player => player.enabled = true);
        FoodSpawn.enabled = true;
        GamePause.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        Players.ForEach(player => player.enabled = false);
        FoodSpawn.enabled = false;
        GamePause.SetActive(true);
    }
}
