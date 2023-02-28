
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private int sceneIndex;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
