using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSpawner : MonoBehaviour
{
    private bool isDead = false;
    private bool isGameStart = false;
    public GameObject spawnerObject;
    private GameObject zombieObject;
    private ZombieSpawner spawner;
    [SerializeField] private float time = 50f;
    [SerializeField] private Text timeText;
    [SerializeField] private Text fpsText;
    private float fpsTimer = 0f;

    private void Awake()
    {
        timeText.text = time.ToString();
    }

    private void Start()
    {
        if (spawnerObject != null)
        {
            spawner = spawnerObject.GetComponent<ZombieSpawner>();
        }
    }

    private void Update()
    {
        fpsTimer += Time.deltaTime;

        if (isGameStart)
        {
            time -= Time.deltaTime;
            timeText.text = (Mathf.FloorToInt(time)).ToString();
        }

        if (isDead)
        {
            if (spawner != null)
            {
                spawner.Spawn();
            }
            isDead = false;
            Destroy(zombieObject);
        }

        if (time < 0)
        {
            Debug.Log("Time's up!");
            timeText.text = "Time's up!";
            isGameStart = false;
            SceneScript.SceneScore = ZombieSpawner.score * 10;
            SceneManager.LoadScene(2);
        }

        if (fpsTimer > 1f)
        {
            float fps = 1f / Time.deltaTime;
            fpsText.text = (Mathf.RoundToInt(fps)).ToString();
            fpsTimer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zombieObject = collision.gameObject;
            isDead = true;
            isGameStart = true;
        }
    }
}
