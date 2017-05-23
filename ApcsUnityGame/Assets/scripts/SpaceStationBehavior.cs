using UnityEngine;
using System.Collections;

public class SpaceStationBehavior : MonoBehaviour {

	public int health;

	public GameObject healthText;

	void Update() {
		if (health <= 0) {
			health = 0;
			Debug.Log("You Lose");
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
