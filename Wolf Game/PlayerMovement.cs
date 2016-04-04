using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 0.2f;         // The speed that the player will move at.


        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.

        void Awake ()
        {
            floorMask = LayerMask.GetMask ("Floor");

            // Set up references.
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void FixedUpdate ()
        {
            // Turn the player to face the mouse cursor and move towards me.
            Move ();
        }


        void Move ()
        {

			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");

			//transform.Rotate(Vector3.up * h * 1.6f);
			transform.Translate (Vector3.forward * v * speed, Space.World);
			transform.Translate (Vector3.right * h * speed, Space.World);

			Vector3 testScale = transform.localScale;

			if (h > 0) {
				testScale.x = -1;
				transform.eulerAngles = new Vector3(0, 270, 0);
			} else if (h < 0){
				testScale.x = 1;
				transform.eulerAngles = new Vector3(0, 90, 0);
			}

			transform.localScale = testScale;
        }
    }
}