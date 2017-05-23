using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour {

	public float speed;

	private float spawnTime;

	public bool isPlayer;

	// Use this for initialization
	void Start () {

		spawnTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (0, speed * Time.deltaTime, 0);


		if (Time.time - spawnTime > 10) {
			Object.Destroy (this.gameObject);
		}
	}

	void setIsPlayer(bool p) {
		isPlayer = p;
	}
}
