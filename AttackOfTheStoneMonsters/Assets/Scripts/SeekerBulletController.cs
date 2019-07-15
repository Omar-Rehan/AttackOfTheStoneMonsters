using UnityEngine;

public class SeekerBulletController : MonoBehaviour {
    // Other game objects
    public GameObject player;
    private GameObject enemySpawner;
    private GameObject targetEnemy = null;
    
    // My components
    public Rigidbody _rigidbody;

    // Members
    public float thrust = 4.0f;
    public float lifeTime = 4.0f;

    void Start() {
        Destroy(gameObject, lifeTime);

        enemySpawner = GameObject.Find("EnemySpawner");

        float minDistance = 1000000;
        targetEnemy = null;
        for (int i = 0; i < enemySpawner.transform.childCount; i++) {
            Transform childTransform = enemySpawner.transform.GetChild(i);
            float distance = (childTransform.position - player.transform.position).magnitude;
            if (minDistance > distance) {
                minDistance = distance;
                targetEnemy = childTransform.gameObject;
            }
        }
    }

    void FixedUpdate() {
        if (targetEnemy == null) {
            _rigidbody.AddForce(transform.up * thrust);
        } else {
            Vector3 targetEnemyCenter = targetEnemy.transform.position;
            targetEnemyCenter.y += 0.5f;

            Vector3 movingDirection = Vector3.Normalize(targetEnemyCenter - transform.position);
            _rigidbody.AddForce(movingDirection * thrust);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor") {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            PlayerManager.score += 2;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
