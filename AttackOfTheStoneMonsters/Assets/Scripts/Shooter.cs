using UnityEngine;

public class Shooter : MonoBehaviour {
    // Other game objects
    public GameObject normalBullet;
    public GameObject seekerBullet;
    public GameObject shootingPoint;

    // Members
    private bool isPointingAtButton;

    private static bool coolDown = false;
    private static float lastSeekerShot;
    public static float coolDownTime = 3.0f;

    void Update() {
        if (coolDown && Time.time - lastSeekerShot > coolDownTime) coolDown = false;

        if (!isPointingAtButton) { // SHOOT!
            if (Input.GetKeyDown(KeyCode.Mouse0)) { // Normal bullet (left click)
                Instantiate(normalBullet, shootingPoint.transform.position, shootingPoint.transform.rotation);

            } else if (Input.GetKeyDown(KeyCode.Mouse1) && !coolDown) { // Seeker bullet (right click)
                Instantiate(seekerBullet, shootingPoint.transform.position, shootingPoint.transform.rotation);

                lastSeekerShot = Time.time;
                coolDown = true;
            }
        }
    }

    public void PointingAtButton() {
        isPointingAtButton = true;
    }
    public void NotPointingAtButton() {
        isPointingAtButton = false;
    }

    public static float GetCoolDownPercentage() {
        if (!coolDown) return 1.0f;
        return (Time.time - lastSeekerShot) / coolDownTime;
    }
}
