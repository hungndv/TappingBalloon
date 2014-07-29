using UnityEngine;
using System.Collections;

public class CactusesScript : MonoBehaviour
{
	private bool isCalculated;

	void Awake ()
	{
		isCalculated = false;
		Destroy (gameObject, 10);
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isCalculated && !ScoreScript.isDead) {
			var balloon = GameObject.FindGameObjectWithTag("Player");
			if (transform.position.x + renderer.bounds.size.x < balloon.transform.position.x) {
				ScoreScript.score++;
				isCalculated = true;
				SoundEffectsHelper.Instance.MakeScoreSound();
			}
		}
	}

}
