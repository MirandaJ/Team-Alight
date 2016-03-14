using UnityEngine;
using System.Collections;

public class heron_movement : MonoBehaviour {

	public bool facingRight = true;

	public float speed;
	public float acceleration;
	public float targetSpeed;
	public float currentSpeed;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {}

	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.A)) {
			if (facingRight) FlipLeft ();
			//transform.position = Vector3=.MoveTowards(transform.position, target.position, step);
			//anim.SetTrigger("WalkLeft");
			//targetSpeed = Input.GetAxisRaw;
			// rb2d.AddForce(m*speed); 
			//transform.Translate(m * Time.deltaTime);
		}
			
		if (Input.GetKeyDown(KeyCode.D)) {
			if (!facingRight) FlipRight ();
			targetSpeed = Input.GetAxisRaw("Horizontal")*speed;
			//transform.Translate(m * Time.deltaTime);
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
