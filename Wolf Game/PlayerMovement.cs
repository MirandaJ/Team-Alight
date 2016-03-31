using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 0.02f;         // The speed that the player will move at.


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
            TurnAndMove ();
        }


        void TurnAndMove ()
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            RaycastHit floorHit;

            if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation (newRotatation);

				float distance = Vector3.Distance (transform.position, floorHit.point);

				Vector3 testScale = transform.localScale;
				if ((floorHit.point.x < transform.position.x)  && transform.localScale.x == -1) {
					testScale.x = 1;
					transform.localScale = testScale;
				} else if ((floorHit.point.x > transform.position.x) && transform.localScale.x == 1) {
					testScale.x = -1;
					transform.localScale = testScale;
				}

				if (distance > 5) {
					transform.position = Vector3.MoveTowards (transform.position, floorHit.point, Vector3.Distance (transform.position, floorHit.point) * speed);
				}
            }
        }
    }
}