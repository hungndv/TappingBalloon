using System;
using System.Collections;

using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	private int scoreFontSize;

	void Awake()
	{
		scoreFontSize = (int)(Screen.height / 15);
	}

	void OnGUI ()
	{
		int buttonWidth = 150;
		int buttonHeight = 60;
		
		if (
			GUI.Button (
			// Center in X, 1/3 of the height in Y
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(5 * Screen.height / 15) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		),
			"Retry!"
		)
			) {
			// Reload the level
			Application.LoadLevel ("TappingBalloon");
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GoogleMobileAdsUnityPluginScript> ().bannerView.Destroy();
		}

		string highestLabel = "Highest: ";
		float areaHeight = scoreFontSize;
		float areaWidth = scoreFontSize * ( 4 + highestLabel.Length);
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = (2.5f * Screen.height / 15) - (areaHeight * 0.5f); 
		GUILayout.BeginArea(new Rect (ScreenX, ScreenY, areaWidth, areaHeight));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		// Load and set Font
		GUIStyle guiStyle = new GUIStyle();
		Font myFont = (Font)Resources.Load("Fonts/kenvector_future", typeof(Font));
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = scoreFontSize;
		guiStyle.font = myFont;
		GUILayout.Label(highestLabel + ScoreScript.HighScore.ToString(), guiStyle);

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		Texture2D goldenBallon = (Texture2D)Resources.Load("GoldenBalloon");
		GUILayout.BeginArea(new Rect (Screen.width/2 - goldenBallon.width/2, Screen.height/2 - goldenBallon.height/2, goldenBallon.width, goldenBallon.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (ScoreScript.IsHighScoreSet)
		{
			ScreenX = ((Screen.width * 0.5f) - (goldenBallon.width * 0.5f));
			GUI.DrawTexture(new Rect(0, 0, goldenBallon.width, goldenBallon.height), goldenBallon, ScaleMode.ScaleAndCrop);
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
}
