using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
	public static int score;
	public static bool isDead;
	private static bool isHighScoreSet;
	private int scoreFontSize;

	void Awake ()
	{
		//HighScore = 0; // to reset HighScore
		score = 0;
		isDead = false;
		isHighScoreSet = false;
		scoreFontSize = (int)(Screen.height / 10);
	}

	public static int HighScore {
		get { return PlayerPrefs.GetInt ("HighScore"); }
		set {
			PlayerPrefs.SetInt ("HighScore", value);
			isHighScoreSet = true;
		}
	}

	public static bool IsHighScoreSet {
		get { return isHighScoreSet; }
	}

	void OnGUI ()
	{
		float areaHeight = scoreFontSize;
		float areaWidth = scoreFontSize * 4;
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = (1 * Screen.height / 15) - (scoreFontSize / 2);
		GUIStyle guiStyle = new GUIStyle ();
		Font myFont = (Font)Resources.Load ("Fonts/kenvector_future", typeof(Font));
		guiStyle.normal.textColor = Color.white;
		guiStyle.font = myFont;
		guiStyle.fontSize = scoreFontSize;
		guiStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (ScreenX, ScreenY, areaWidth, areaHeight), score.ToString (), guiStyle);
	}
}
