using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour
{
	private bool hasSpawn;

	void Awake ()
	{
	}

	// Use this for initialization
	void Start ()
	{
		hasSpawn = false;		
		// Disable everything
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hasSpawn == false) {
			if (renderer.IsVisibleFrom (Camera.main)) {
				Spawn ();
			}
		} else {
			if (renderer.IsVisibleFrom (Camera.main) == false) {
				Destroy (gameObject);
			}
		}
	}

	private void Spawn ()
	{
		hasSpawn = true;
		
		// Enable everything
	}
}
