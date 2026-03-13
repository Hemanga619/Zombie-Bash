using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    [HideInInspector] public static int SceneScore;
    [SerializeField] private Text sceneScoreText;

    private void Start()
    {
        sceneScoreText.text = SceneScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
