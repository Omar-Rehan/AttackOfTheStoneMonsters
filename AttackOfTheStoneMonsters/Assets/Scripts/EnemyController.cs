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
        movingDirection.y -= 0.5f; // center of the stone monster is a little lower than the actual head
        movingDirection = Vector3.Normalize(movingDirection);

        transform.forward = movingDirection;
    }

    void FixedUpdate() {
        _rigidbody.AddForce(movingDirection * movementSpeed);
    }
}
