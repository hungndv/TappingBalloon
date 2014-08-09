using System;
using System.Collections;

using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	private int scoreFontSize;

	void Awake ()
	{
		scoreFontSize = (int)(Screen.height / 15);		
		GameObject.FindGameObjectWithTag ("GameController").AddComponent<GoogleMobileAdsUnityPluginScript> ();
	}

	private void PrintTopScore ()
	{
		string highestLabel = "TOP: ";
		float areaHeight = scoreFontSize;
		float areaWidth = scoreFontSize * (4 + highestLabel.Length);
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = (2.5f * Screen.height / 15) - (areaHeight * 0.5f); 
		GUILayout.BeginArea (new Rect (ScreenX, ScreenY, areaWidth, areaHeight));
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		// Load and set Font
		GUIStyle guiStyle = new GUIStyle ();
		Font myFont = (Font)Resources.Load ("Fonts/kenvector_future", typeof(Font));
		if (ScoreScript.IsHighScoreSet) 
			guiStyle.normal.textColor = Color.yellow;
		else
			guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = scoreFontSize;
		guiStyle.font = myFont;
		GUILayout.Label (highestLabel + ScoreScript.HighScore.ToString (), guiStyle);
		
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
	}

	void OnGUI ()
	{
		int buttonWidth = DemensionConstants.ButtonWidth;
		int buttonHeight = DemensionConstants.ButtonHeight;

		PrintTopScore ();

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(4.5f * Screen.height / 15) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		),
			"Retry!"
		)
			) {
			// Reload the level
			Destroy(GameObject.FindGameObjectWithTag ("GameController").GetComponent<GoogleMobileAdsUnityPluginScript> ());
			Application.LoadLevel ("TappingBalloon");
		}

		int facebookButtonWidth = buttonWidth;
		int faceBookButtonHeight = 30;
		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - facebookButtonWidth / 2, (7 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth, faceBookButtonHeight),
			"FaceBook"
		)
			) {
			Application.OpenURL ("https://www.facebook.com/dialog/share" +
			                     "?app_id=" + "1647330075492824" +
				"&display=popup" +
			                     "&href=https%3A%2F%2Fwww.facebook.com%2Fgames%2Fhungndv%2F%3Ffbs%3D-1%26preview%3D1%26locale%3Den_US" +
				"&redirect_uri=" + WWW.EscapeURL ("https://www.facebook.com/"));

		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - facebookButtonWidth / 2, (9 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth, faceBookButtonHeight),
			"Twitter"
		)
			) {
			Application.OpenURL ("https://www.facebook.com/dialog/share" +
			                     "?app_id=" + "1647330075492824" +
				"&display=popup" +
			                     "&href=https%3A%2F%2Fwww.facebook.com%2Fgames%2Fhungndv%2F%3Ffbs%3D-1%26preview%3D1%26locale%3Den_US" +
				"&redirect_uri=" + WWW.EscapeURL ("https://www.facebook.com/"));
			
		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (Screen.width / 2 - facebookButtonWidth / 2, (11 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth, faceBookButtonHeight),
			"Google+"
		)
			) {
			Application.OpenURL ("https://www.facebook.com/dialog/share" +
			                     "?app_id=" + "1647330075492824" +
				"&display=popup" +
				"&href=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2F" +
				"&redirect_uri=" + WWW.EscapeURL ("https://www.facebook.com/"));
			
		}
	}
}
