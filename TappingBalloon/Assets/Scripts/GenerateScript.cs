using UnityEngine;
using System.Collections;

public class GenerateScript : MonoBehaviour
{
	public GameObject obstacle;
	public float[] randomYs;

	void Awake ()
	{
	}

	// Use this for initialization
	void Start ()
	{
		// The second is the number of seconds to delay these repeated calls. 
		// And the third parameter is the number of seconds between method calls.
		InvokeRepeating ("CreateObstacle", 1.3f, 1.3f);
	}

	void CreateObstacle ()
	{
		var random = new System.Random ();
		var randomY = randomYs [random.Next (0, randomYs.Length)];
		var position = new Vector3 (0, randomY);
		Instantiate (obstacle, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
