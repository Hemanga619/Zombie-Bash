using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnRadius = 3f;
    [SerializeField] private Text scoreText;
    public static int score = 0;

    public void Spawn()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(transform.position.x + randomPoint.x, transform.position.y + 0.33f, transform.position.z + randomPoint.y);

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        
        score++;
        scoreText.text = (score * 10).ToString();
    }
}