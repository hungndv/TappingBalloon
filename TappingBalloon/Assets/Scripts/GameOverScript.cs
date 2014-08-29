using System;
using System.Collections;

using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	private int scoreFontSize;
	
	private static Rect retryButtonRect = new Rect (Screen.width / 2 - (DemensionConstants.ButtonWidth / 2), (4.5f * Screen.height / 15) - (DemensionConstants.ButtonHeight / 2), DemensionConstants.ButtonWidth, DemensionConstants.ButtonHeight);
	private static Texture2D facebookImage = Resources.Load ("facebook") as Texture2D;
	private static Rect facebookShareRect = new Rect (Screen.width / 2 - DemensionConstants.ButtonWidth / 2, (7 * Screen.height / 15) - DemensionConstants.ButtonHeight / 2, DemensionConstants.ButtonWidth / 2 - DemensionConstants.Gap / 2, DemensionConstants.ButtonHeight);
	private static Rect facebookLikeRect = new Rect (Screen.width / 2 - DemensionConstants.ButtonWidth / 2 + (DemensionConstants.ButtonWidth / 2 + DemensionConstants.Gap / 2), (7 * Screen.height / 15) - DemensionConstants.ButtonHeight / 2, DemensionConstants.ButtonWidth / 2 - DemensionConstants.Gap / 2, DemensionConstants.ButtonHeight);
	private static Texture2D twitterImage = Resources.Load ("twitter") as Texture2D;
	private static Rect twitterRect = new Rect (Screen.width / 2 - DemensionConstants.ButtonWidth / 2, (9.5f * Screen.height / 15) - DemensionConstants.ButtonHeight / 2, DemensionConstants.ButtonWidth, DemensionConstants.ButtonHeight);
	private static Texture2D googlePlusImage = Resources.Load ("googleplus") as Texture2D;
	private static Rect googlePlusRect = new Rect (Screen.width / 2 - DemensionConstants.ButtonWidth / 2, (12 * Screen.height / 15) - DemensionConstants.ButtonHeight / 2, DemensionConstants.ButtonWidth, DemensionConstants.ButtonHeight);

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
		if (ScoreScript.IsHighScoreSet) {
			guiStyle.normal.textColor = Color.yellow;
			Social.ReportScore(ScoreScript.score, "CgkIo9bRjfsBEAIQAQ", (bool success) => {
				// handle success or failure
			});
		}
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
		PrintTopScore ();

		GUI.skin.button.fontSize = DemensionConstants.DefaultFontSize;

		if (
			GUI.Button (
				// Center in X, 1/3 of the height in Y
				//new Rect (Screen.width / 2 - (buttonWidth / 2), (4.5f * Screen.height / 15) - (buttonHeight / 2), buttonWidth, buttonHeight), 
				retryButtonRect,
				"Retry!"))
		{
			// Reload the level
			Destroy (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GoogleMobileAdsUnityPluginScript> ());
			Application.LoadLevel ("TappingBalloon");
		}


		if (
			GUI.Button (
				// Center in X, 1/3 of the height in Y
				//new Rect (Screen.width / 2 - facebookButtonWidth / 2, (7 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth / 2 - DemensionConstants.Gap / 2, faceBookButtonHeight),
				facebookShareRect,
				new GUIContent ("Share", facebookImage, "Share on FaceBook."))
			) {
			Application.OpenURL ("https://www.facebook.com/sharer/sharer.php?app_id=113869198637480&sdk=joey&u=https%3A%2F%2Fwww.facebook.com%2Ftappingballoongame&display=popup&ref=plugin");

		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			//new Rect (Screen.width / 2 - facebookButtonWidth / 2 + (facebookButtonWidth / 2 + DemensionConstants.Gap / 2), (7 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth / 2 - DemensionConstants.Gap / 2, faceBookButtonHeight),
			facebookLikeRect,
			new GUIContent ("Like", facebookImage, "Like us on FaceBook."))
			) {
			Application.OpenURL ("http://www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Ftappingballoongame&width&layout=standard&action=like&show_faces=true&share=true&height=80&appId=1647330075492824");
			
		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			//new Rect (Screen.width / 2 - facebookButtonWidth / 2, (9.5f * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth, faceBookButtonHeight),
			twitterRect,
			new GUIContent (twitterImage, "Share on Twitter.")
		)
			) {
			Application.OpenURL ("https://twitter.com/home?status=https://www.facebook.com/tappingballoongame");
		}

		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			//new Rect (Screen.width / 2 - facebookButtonWidth / 2, (12 * Screen.height / 15) - faceBookButtonHeight / 2, facebookButtonWidth, faceBookButtonHeight),
			googlePlusRect,
			new GUIContent (googlePlusImage, "Share on Google+.")
		)
			) {
			Application.OpenURL ("https://plus.google.com/share?url=https://www.facebook.com/tappingballoongame");
			
		}
	}
}
