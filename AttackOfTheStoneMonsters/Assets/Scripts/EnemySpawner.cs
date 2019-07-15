using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    // Other game objects
    public GameObject player;
    public GameObject enemyPrefab;

    // Members
    //public float enemyHeight;
    private float lastSpawnTime;

    void Start() {
        lastSpawnTime = 0.0f;
    }

    void Update() {
        if (Time.time - lastSpawnTime > 1.5f) SpawnEnemy(); 
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, RandomizeNewEnemyPosition(), Quaternion.identity, gameObject.transform);
        lastSpawnTime = Time.time;
    }

    Vector3 RandomizeNewEnemyPosition() {
        /// Randomize the enemy's direction from the player (Vector3)
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(0.0f, 5.0f);
        float z = Random.Range(5.0f, 10.0f);
        Vector3 enemyDirection = Vector3.Normalize(new Vector3(x, y, z)); // magnitude = 1.0f

        /// Randomize the enemy's distance
        float distance = Random.Range(30, 50);

        /// Calculate the enemy's final position
        Vector3 enemyPosition = (distance * enemyDirection) + player.transform.position;
        return enemyPosition;

        //float minX = floor.transform.position.x - floor.gameObject.GetComponent<Renderer>().bounds.size.x / 2;
        //float maxX = floor.transform.position.x + floor.gameObject.GetComponent<Renderer>().bounds.size.x / 2;

        //float minZ = floor.transform.position.z - floor.gameObject.GetComponent<Renderer>().bounds.size.z / 2 + 5.0f;
        //float maxZ = floor.transform.position.z + floor.gameObject.GetComponent<Renderer>().bounds.size.z / 2;

        //float newEnemyX = Random.Range(minX, maxX);
        //float newEnemyZ = Random.Range(minZ, maxZ);

        //return new Vector3(newEnemyX, enemyHeight, newEnemyZ);
    }
}
