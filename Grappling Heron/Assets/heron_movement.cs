using UnityEngine;
using System.Collections;

public class heron_movement : MonoBehaviour {

	public float speed = 5f;
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
			if (facingRight) FlipLeft ();
			//transform.position = Vector3=.MoveTowards(transform.position, target.position, step);
			//anim.SetTrigger("WalkLeft");
			Vector2 m = new Vector2 (-20f,0f);
			// rb2d.AddForce(m*speed); 
			transform.Translate(m * Time.deltaTime);
		}
			
		if (Input.GetKeyDown(KeyCode.D)) {
			if (!facingRight) FlipRight ();
			// Vector2 m = new Vector2 (10f, 0f);
			// rb2d.AddForce(m*speed); 
			//transform.position = Vector3.MoveTowards(transform.position, target.position, 10*Time.deltaTime);
			Vector2 m = new Vector2 (20f,0f);
			// rb2d.AddForce(m*speed); 
			transform.Translate(m * Time.deltaTime);
		}
	}

	void FlipRight () {
		facingRight = true;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	void FlipLeft () {
		facingRight = false;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
}
