using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static int score = 0;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            score -= 5;
            Destroy(other.gameObject);
        }
    }
}
