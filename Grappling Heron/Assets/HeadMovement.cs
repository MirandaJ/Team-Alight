using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

	public bool facingRight = true;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {}

	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.A)) {
			Flip (); }
			
		if (Input.GetKeyDown(KeyCode.D)) {
			Flip (); }

		if (Input.GetMouseButtonDown(0)) {
			Grapple ();
		}
	}

	void Grapple () {
		//Debug.Log(transform.position.x - Input.mousePosition.x);
		if (System.Math.Abs(transform.position.x - Input.mousePosition.x) < 250f) {
			if (System.Math.Abs(transform.position.y - Input.mousePosition.y) < 250f) {
				Vector2 angle = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				transform.position =  Vector2.MoveTowards(transform.position, angle, 5f);
			}
		}

	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
}
