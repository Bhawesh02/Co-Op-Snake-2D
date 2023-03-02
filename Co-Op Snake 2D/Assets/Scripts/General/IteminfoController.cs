
using System;
using UnityEngine;
using UnityEngine.UI;

public class IteminfoController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    private void Start()
    {
        GameManager.Instance.PauseGame();
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
