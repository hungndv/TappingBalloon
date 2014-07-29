using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	public static int score;
	public static bool isDead;

	void Awake()
	{
		score = 0;
		isDead = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.color = Color.black;
		GUILayout.Label(" Score: " + score.ToString());
	}
}
