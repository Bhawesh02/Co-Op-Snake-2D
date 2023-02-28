
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverUIController : MonoBehaviour
{
    private GameMode mode;

    [SerializeField]
    private TextMeshProUGUI message;


    [SerializeField]
    private Button replay;

    private void Awake()
    {
        mode = (GameMode)PlayerPrefs.GetInt("GameMode");
        replay.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        if (mode == GameMode.Solo)
            SoloGameOver();
        else
            CoopGameOver();


    }

    private void SoloGameOver()
    {
        PlayerController player = GameManager.Instance.players[0];
        message.text="Game Over\nFinal Score: "+player.currentScore;
    }
    private void CoopGameOver()
    {
        message.text = "Game Over\nPlayer " + GameManager.Instance.playerLostId + " Lost";
    }

}
