using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject station;

	public GameObject missile;

    public GameObject scoreText;

	public float speed;

	public float shootDistance;

	private float lastShootTime;

	public float shootDelay;

	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float distance = Vector3.Distance (transform.position, station.transform.position);
		
		if (distance < shootDistance) {

			if (Time.time - lastShootTime >= shootDelay) {

				GameObject m = (GameObject)Instantiate(missile, transform.TransformPoint(offset), transform.rotation);
				m.SendMessage("setIsPlayer", false);
				lastShootTime = Time.time;
			}

		} else {
			Vector3 diff = station.transform.position - transform.position;

			float angle = (Mathf.Atan2(diff.y , diff.x) - Mathf.PI / 2) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			transform.Translate (0, speed * Time.deltaTime, 0);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {

        ScoreController.get().score += 10;
        scoreText.GetComponent<Text>().text = "Score: " + ScoreController.get().score;
		Object.Destroy (other.gameObject);
		Object.Destroy (this.gameObject);
	}
}
