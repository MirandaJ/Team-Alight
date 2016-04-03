using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerAttack : MonoBehaviour
    {
        public int damagePerBlow = 20;                  // The damage inflicted by each blow.
		public int damagePerBite = 50;                  // The damage inflicted by each bit.
        public float timeBetweenBlows = 0.15f;          // The time between each blow.
        public float blowRange = 8f;                    // The distance the blow can hit.
		public float biteRange = 3f;                    // The distance the bite can hit.
		public float knockBack = 4f;					// How far the average enemy is knocked back by blow.
		public AudioClip blowAudio;                     // Reference to the audio source.
		public AudioClip biteAudio;                     // Reference to the audio source.


        float timer;                                    // A timer to determine when to blow.
        Ray attackRay;                                  // A ray from the mouth forwards.
        RaycastHit attackHit;                           // A raycast hit to get information about what was hit.
        int attackableMask;                             // A layer mask so the raycast only hits things on the attackable layer.
        LineRenderer attackLine;                        // Reference to the line renderer.
        float effectsDisplayTime = 0.4f;                // The proportion of the timeBetweenBlows that the effects will display for.
		AudioSource audio;


        void Awake ()
        {
            // Create a layer mask for the Attackable layer.
            attackableMask = LayerMask.GetMask ("Attackable");

            // Set up the references.
            attackLine = GetComponent <LineRenderer> ();
			audio = GetComponent<AudioSource>();
        }


        void Update ()
        {
            timer += Time.deltaTime;

			if(Input.GetKeyDown(KeyCode.X) && timer >= timeBetweenBlows && Time.timeScale != 0)
            {
                Blow ();
            }

			if(Input.GetKeyDown(KeyCode.Z) && timer >= timeBetweenBlows && Time.timeScale != 0)
			{
				Bite ();
			}

            if(timer >= timeBetweenBlows * effectsDisplayTime)
            {
                DisableEffects ();
            }
        }


        public void DisableEffects ()
        {
            attackLine.enabled = false;
        }


        void Blow ()
        {
            // Reset the timer.
            timer = 0f;

			audio.PlayOneShot(blowAudio);

            attackLine.enabled = true;
            attackLine.SetPosition (0, transform.position);

			attackRay.origin = transform.position + Vector3.down;
            attackRay.direction = transform.forward;

            if(Physics.Raycast (attackRay, out attackHit, blowRange, attackableMask))
            {
                EnemyHealth enemyHealth = attackHit.collider.GetComponent <EnemyHealth> ();

				if (enemyHealth != null) {
					enemyHealth.TakeDamage (damagePerBlow, attackHit.point);
					attackHit.transform.Translate (Vector3.back * knockBack, Space.Self);
				}

                attackLine.SetPosition (1, attackHit.point);
            }
            // If the raycast didn't hit anything on the attackable layer...
            else
            {
                attackLine.SetPosition (1, attackRay.origin + attackRay.direction * blowRange);
            }
        }

		void Bite ()
		{
			timer = 0f;

			audio.PlayOneShot(biteAudio);

			attackRay.origin = transform.position + Vector3.down;
			attackRay.direction = transform.forward;

			if(Physics.Raycast (attackRay, out attackHit, biteRange, attackableMask))
			{
				EnemyHealth enemyHealth = attackHit.collider.GetComponent <EnemyHealth> ();

				if (enemyHealth != null) {
					enemyHealth.TakeDamage (damagePerBite, attackHit.point);
					attackHit.transform.Translate (Vector3.back * knockBack);
				}

				attackLine.SetPosition (1, attackHit.point);
			}
			else
			{
				attackLine.SetPosition (1, attackRay.origin + attackRay.direction * blowRange);
			}
		}
    }
}