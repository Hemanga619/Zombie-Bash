using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    [HideInInspector] public static int SceneScore;
    [SerializeField] private Text sceneScoreText;

    private void Start()
    {
        if (sceneScoreText != null)
        {
            sceneScoreText.text = SceneScore.ToString();
        }
    }

    public void PlayGame()
    {
        SceneScore = 0;
        ZombieSpawner.score = 0;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
