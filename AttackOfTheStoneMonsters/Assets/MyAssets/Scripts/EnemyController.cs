using UnityEngine;

public class EnemyController : MonoBehaviour {
    // Other game objects
    private GameObject player;

    // My components
    public Rigidbody _rigidbody;

    // Members
    public float movementSpeed;
    private Vector3 movingDirection;


    void Start() {
        player = GameObject.FindWithTag("Player");

        movingDirection = player.transform.position - this.gameObject.transform.position;
        movingDirection.y -= 1.0f; // center of the stone monster is a little lower than the actual head
        movingDirection = Vector3.Normalize(movingDirection);

        transform.forward = movingDirection;
    }
    void FixedUpdate() {
        _rigidbody.AddForce(movingDirection * movementSpeed);
    }

    public void KillOwner() {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        movingDirection = -movingDirection;

        gameObject.GetComponent<Animation_Test>().DeathAni();
        Destroy(gameObject.gameObject, 1.0f);
    }
}
