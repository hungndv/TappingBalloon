﻿using UnityEngine;
using System.Collections;

public class GenerateScript : MonoBehaviour
{
	public GameObject obstacle;
	public float[] randomYs;
	public float dalayedTime = 1.3f;
	public float rateTime = 1.3f;
	//private float forTest = 2.5f;

	void Awake ()
	{
	}

	// Use this for initialization
	void Start ()
	{
		// The second is the number of seconds to delay these repeated calls. 
		// And the third parameter is the number of seconds between method calls.
		InvokeRepeating ("CreateObstacle", dalayedTime, rateTime);
	}

	void CreateObstacle ()
	{
		//forTest = forTest == 2.5f ? -2.5f: forTest == -2.5f ? 2.5f : 0;
		var random = new System.Random ();
		var randomY = randomYs [random.Next (0, randomYs.Length)];
		//randomY = forTest;
		var position = new Vector3 (1, randomY);
		Instantiate (obstacle, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
