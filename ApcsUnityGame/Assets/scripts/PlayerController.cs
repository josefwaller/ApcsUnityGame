/*
 * PlayerController.cs
 * 
 * Controls the Player GameObject. Moves it when
 * the up or down keys are pressed, turns it 
 * when the left or right keys are pressed
 * and fires when space is pressed.
 */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// the speed the player moves at
	public float speed;

	// the speed the player turns at
	public float turnSpeed;

	// the missile gasme object
	public GameObject missile;

	// the offset to create the missiles
	public Vector3 missileOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Checks for rotating the player
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(0, 0, turnSpeed * Time.deltaTime);

		}else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0, 0, - turnSpeed * Time.deltaTime);
		}

		// checks for moving the player forwards/backwards
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (0, speed * Time.deltaTime, 0);

		} else if (Input.GetKey(KeyCode.DownArrow)) {

			// moves backwards at half speed
			transform.Translate (0, - speed * Time.deltaTime / 2, 0);
		}

		// checks for shooting
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			Instantiate(missile, 
	            transform.TransformPoint(missileOffset), 
	            transform.rotation);
			Instantiate(missile, 
	            transform.TransformPoint(
				new Vector3(-missileOffset.x, missileOffset.y, missileOffset.z)), 
	            transform.rotation);


		}
	}
}
