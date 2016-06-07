using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	//Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed at which the AppleTree moves in meters/second
	public float speed = 1f;

	//Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;

	//Chance the apple tree will change directions
	public float chanceToChangeDirections = 0.1f;

	//Rate at which apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;

	void Start () {
		//Drops apples every second
	}
	
	// Update is called once per frame
	void Update () {
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//Changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //move right
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); //move left
		}
	}

	void FixedUpdate(){
		if (Random.value < chanceToChangeDirections) {
			speed *= -1; //change directions
		}
	}
}