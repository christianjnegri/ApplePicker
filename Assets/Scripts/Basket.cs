using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;
	// Use this for initialization
	void Start () {
		//Find a reference to the ScoreCounter GameOBject
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		//Get the GUIText Component of the GameObject
		scoreGT = scoreGO.GetComponent<GUIText>();
		//Set the starting number of points to 0
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		//Get the current screen position of the mouse
		Vector3 mousePos2D = Input.mousePosition;

		//Camera's Z position sets how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; //2

		//Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //3

		//Move the x position of this basket to the x position of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision coll) {
		//Find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
		//Parse the text of the scoreGT into an int
		int score = int.Parse(scoreGT.text);
		//Add points for catching an apple
		score += 100;
		//Convert the score back to a spring for display
		scoreGT.text = score.ToString();
	}
}
