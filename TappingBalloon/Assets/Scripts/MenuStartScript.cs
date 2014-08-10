using UnityEngine;
using System.Collections;

public class MenuStartScript : MonoBehaviour
{
	GenerateScript generateScript;
	ScoreScript scoreScript;

	void Awake ()
	{
		var controllerScript = GameObject.FindGameObjectWithTag ("GameController");
		generateScript = controllerScript.GetComponent<GenerateScript> ();
		scoreScript = controllerScript.GetComponent<ScoreScript> ();
	}

	// Use this for initialization
	void Start ()
	{
		generateScript.enabled = false;
		scoreScript.enabled = false;
	}

	void OnGUI ()
	{
		GUI.skin.button.fontSize = DemensionConstants.DefaultFontSize;

		int buttonWidth = DemensionConstants.ButtonWidth;
		int buttonHeight = DemensionConstants.ButtonHeight;

		Texture2D logo  = Resources.Load("logo") as Texture2D;
		GUI.Label (
			new Rect (Screen.width / 2 - logo.width / 2, (3 * Screen.height / 15) - logo.height / 2, logo.width, logo.height),
			new GUIContent(logo)
		           );

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - (buttonWidth / 2), (5 * Screen.height / 15) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
			), "Tap to pull!") ||
			Input.GetButtonDown ("Fire1") || Input.GetKeyDown (KeyCode.DownArrow) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Stage1");
			enabled = false;
			generateScript.enabled = true;
			scoreScript.enabled = true;
		}
	}
}
