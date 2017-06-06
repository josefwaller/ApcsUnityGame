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

    public GameObject controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.AngleAxis(-90 + 180 * controller.GetComponent<MovementController>().getAngle() / Mathf.PI, Vector3.forward);
        transform.Translate(0, Time.deltaTime * speed * controller.GetComponent<MovementController>().getOffset(), 0);

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
