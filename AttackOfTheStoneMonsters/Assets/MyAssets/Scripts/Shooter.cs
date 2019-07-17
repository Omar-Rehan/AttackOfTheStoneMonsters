using UnityEngine;

public class Shooter : MonoBehaviour {
    private bool isPointingAtButton;
    public GameObject shootingPoint;

    /// Bullet members
    public GameObject[] BulletTypes;
    enum BulletType {NormalBullet, SeekerBullet}
    private BulletType currentBulletType;


    // Cooldown members
    private static bool isInCoolDown;
    public static float coolDownTime;
    private static float lastSeekerShot;

    void Start() {
        currentBulletType = BulletType.NormalBullet;

        isInCoolDown = false;
        coolDownTime = 3.0f;
    }
    void Update() {
        if (isInCoolDown && Time.time - lastSeekerShot > coolDownTime) isInCoolDown = false;

        if (!isPointingAtButton && Input.GetKeyDown(KeyCode.Mouse0)) { // SHOOT!
            if (currentBulletType == BulletType.NormalBullet) {
                Instantiate(BulletTypes[(int)BulletType.NormalBullet], shootingPoint.transform.position, shootingPoint.transform.rotation);

            } else if (currentBulletType == BulletType.SeekerBullet && !isInCoolDown) {
                Instantiate(BulletTypes[(int)BulletType.SeekerBullet], shootingPoint.transform.position, shootingPoint.transform.rotation);

                lastSeekerShot = Time.time;
                isInCoolDown = true;
            }
        }
    }

    public void PointingAtButton() {
        isPointingAtButton = true;
    }
    public void NotPointingAtButton() {
        isPointingAtButton = false;
    }

    public void SwitchBulletType() {
        currentBulletType = (BulletType)((int)(currentBulletType + 1) % 2);
    }
    public static float GetCoolDownPercentage() {
        return Mathf.Clamp((Time.time - lastSeekerShot) / coolDownTime, 0.0f, 1.0f);
    }
}
