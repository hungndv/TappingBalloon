using UnityEngine;
using System.Collections;

public class MenuStartScript : MonoBehaviour {
	GenerateScript generateScript;

	void Awake()
	{
		var controllerScript = GameObject.FindGameObjectWithTag("GameController");
		generateScript = controllerScript.GetComponent<GenerateScript>();
	}

	// Use this for initialization
	void Start () {
		generateScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		int buttonWidth = 150;
		int buttonHeight = 60;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(5 * Screen.height / 15) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Tap to pull!"
			))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Stage1");
			enabled = false;
			generateScript.enabled = true;

		}
	}
}
