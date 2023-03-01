
using UnityEngine;
using UnityEngine.UI;

public class GamePauseContoller : MonoBehaviour
{
    [SerializeField]
    private Button replayButton;

    private void Start()
    {
        replayButton.onClick.AddListener(GameManager.Instance.RestartLevel);
    }
    private void OnEnable()
    {
        SoundManager.Instance.PauseSound();
    }
    private void OnDisable()
    {
        SoundManager.Instance.ResumeSound();

    }
}
