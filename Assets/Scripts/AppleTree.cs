using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	//Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed atwhich apples fall in meters/second
	public float speed = 1f;

	//Distance where apple tree turns around
	public float leftAndRightEdge = 10f;

	//Chance that apple tree will change direction
	public float chanceToChangeDirection = 0.2f;

	//Rate at which apples will be dropped
	public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start () {
		//Dropping apples every second
		InvokeRepeating("DropApple", 2, secondsBetweenAppleDrops);
	}
	void DropApple() {
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	// Update is called once per frame
	void Update () {
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//Changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); 
			// Move right 
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); 
			// Move left
		} 
	}

	void FixedUpdate() {
		//Changing Direction Randomly
		if (Random.value < chanceToChangeDirection) {
			speed *= -1; //Change Direction
		}
	}
}
