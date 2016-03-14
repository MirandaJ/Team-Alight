using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

	public bool facingRight = true;
	public float grappleSpeed = 10f;
	private bool isGrappling = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	public Transform body;
	public Transform headPosition;

	// Use this for initialization
	void Start () {
		//rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {}

	void FixedUpdate () {

		if(Input.GetKeyDown(KeyCode.A)) {
			if (facingRight) FlipLeft (); }
			
		if (Input.GetKeyDown(KeyCode.D)) {
			if (!facingRight) FlipRight (); }

		if (Input.GetMouseButtonDown(0)) {
			Grapple ();
		}
		else if(!isGrappling) transform.position = headPosition.position;
	}

	void Grapple () {
		//Debug.Log(Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    	RaycastHit hit;
    	if (Physics.Raycast(ray, out hit)){
			// the object identified by hit.transform was clicked
			// do whatever you want
			Debug.Log(hit.transform.tag);
			if(hit.transform.tag == "Grapple") {
				if(!isGrappling) StartCoroutine(moveHead(hit.transform.position));
			}
    	}

	}

	IEnumerator moveHead(Vector3 grappleLocation) {
		//Move head
		isGrappling = true;
		while (transform.position != grappleLocation) {
			yield return null;
			float step = grappleSpeed * Time.deltaTime;
        	transform.position = Vector3.MoveTowards(transform.position, grappleLocation, step);
		}

		//Move body
		while (body.transform.position != grappleLocation) {
			yield return null;
			float step = grappleSpeed * Time.deltaTime;
        	body.transform.position = Vector3.MoveTowards(body.transform.position, grappleLocation, step);
		}
		isGrappling = false;
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
