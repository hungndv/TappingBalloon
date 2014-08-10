using UnityEngine;
using System.Collections;

public class BalloonScript : MonoBehaviour
{
	private Animator animator;

	// The force which is added when the player pulling
	// This can be changed in the Inspector window
	public Vector2 pullForce = new Vector2 (0, -1f);

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		Vector3 startWorldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 4, Screen.height / 2, transform.position.z));
		transform.position = new Vector3 (startWorldPoint.x - renderer.bounds.size.x / 2, startWorldPoint.y, startWorldPoint.z);

		//float width = gameObject.GetComponent<Mesh>().bounds.size.x * transform.localScale.x;
	}

	// Use this for initialization
	void Start ()
	{
		//gameObject.camera.pixelRect = new Rect(Screen.width - xPos, Screen.height - yPos, width, height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") || Input.GetKeyDown (KeyCode.DownArrow) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (pullForce);
			
			SoundEffectsHelper.Instance.MakeHittingSound ();
		}

		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (1, 0, dist)
		).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 1, dist)
		).y;
		
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);
		
		// End of the update method
	}

	void OnCollisionEnter2D (Collision2D info)
	{
		SoundEffectsHelper.Instance.MakeExplosionSound ();
		animator.SetBool ("aboutToExplode", true);
		DoSomething ();

		Destroy (gameObject, 0.5f);

		ScoreScript.isDead = true;
		GameObject.FindGameObjectWithTag ("GameController").AddComponent<GameOverScript> ();
	}

	private void DoSomething ()
	{
		//animator.enabled = false;
		collider2D.enabled = false;
	}
}
