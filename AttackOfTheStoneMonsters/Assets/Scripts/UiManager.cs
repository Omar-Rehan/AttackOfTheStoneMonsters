using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Text scoreText;
    public Image coolDownBar;

    void Update() {
        scoreText.text = "Score: " + PlayerManager.score;
        coolDownBar.fillAmount = Shooter.GetCoolDownPercentage();
    }
}
