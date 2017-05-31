using UnityEngine;
using System.Collections;

public class SpaceStationBehavior : MonoBehaviour {

	public int health;

	public GameObject healthText;

    public GameObject gameOverScreen;

	void Update() {
		if (health <= 0) {
			health = 0;

            gameOverScreen.SetActive(true);

            GameObject.Destroy(this);

		}

		healthText.GetComponent<GUIText> ().text = "Space Station Health: " + health;
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.GetComponent<MissileBehavior> () != null) {

			if (other.gameObject.GetComponent<MissileBehavior>().isPlayer == false) {
				health -= 10;
				GameObject.Destroy(other.gameObject);
			}

		}
	}
}
