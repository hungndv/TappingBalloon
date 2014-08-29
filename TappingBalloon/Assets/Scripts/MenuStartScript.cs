using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuStartScript : MonoBehaviour
{
	GenerateScript generateScript;
	ScoreScript scoreScript;

	void Awake ()
	{
		var controllerScript = GameObject.FindGameObjectWithTag ("GameController");
		generateScript = controllerScript.GetComponent<GenerateScript> ();
		scoreScript = controllerScript.GetComponent<ScoreScript> ();

		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
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

		Texture2D logo = Resources.Load ("logo") as Texture2D;
		GUI.Label (
			new Rect (Screen.width / 2 - logo.width / 2, (3 * Screen.height / 15) - logo.height / 2, logo.width, logo.height),
			new GUIContent (logo)
		);

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - (buttonWidth / 2), (7 * Screen.height / 15) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
		), "Tap to pull!")
		) {
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Stage1");
			enabled = false;
			generateScript.enabled = true;
			scoreScript.enabled = true;
		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - (buttonWidth / 2), (10 * Screen.height / 15) - (buttonHeight / 2),
		          buttonWidth,
		          buttonHeight
		), "Top Gamers")
			) {
			if (!Social.localUser.authenticated) {
				// authenticate user:
				Social.localUser.Authenticate ((bool success) => {
					// handle success or failure
					//Debug.Log(success);
					if (success)
						Social.ShowLeaderboardUI ();
				});
			} else {
				Social.ShowLeaderboardUI ();
			}
		}
	}
}
