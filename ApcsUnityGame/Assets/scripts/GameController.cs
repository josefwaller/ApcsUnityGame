using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float minSpawnDistance;

	private float lastSpawnTime;
	public float spawnDelay;

	public GameObject enemy;
	public GameObject station;
    public GameObject scoreText;

	// Use this for initialization
	void Start () {
		Debug.Log ("Controlling");
		lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time - lastSpawnTime >= spawnDelay) {

			float theta = Random.value * 2 * Mathf.PI;

			GameObject thisEnemy = (GameObject)Instantiate(enemy, new Vector3(
				minSpawnDistance * Mathf.Cos(theta),
				minSpawnDistance * Mathf.Sin(theta),
				0
				), new Quaternion());

			thisEnemy.GetComponent<EnemyBehavior>().station = station;
            thisEnemy.GetComponent<EnemyBehavior>().scoreText = scoreText;

			lastSpawnTime = Time.time;

			spawnDelay -= 0.05f;
		}

	}
}
