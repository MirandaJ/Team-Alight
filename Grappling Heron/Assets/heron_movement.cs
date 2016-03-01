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
			Flip ();
			//anim.SetTrigger("WalkLeft");
			Vector2 move = new Vector2 (-10f,0f);
			rb2d.AddForce(move*speed); }
			
		if (Input.GetKeyDown(KeyCode.D)) {
			Flip ();
			Vector2 move = new Vector2 (10f, 0f);
			rb2d.AddForce(move*speed); }
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
}
