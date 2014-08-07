using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour
{
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectsHelper Instance;
	public AudioClip explosionSound;
	public AudioClip hittingSound;
	public AudioClip scoreSound;

	void Awake ()
	{
		// Register the singleton
		if (Instance != null) {
			Debug.LogError ("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	public void MakeExplosionSound ()
	{
		MakeSound (explosionSound);
	}

	public void MakeHittingSound ()
	{
		MakeSound (hittingSound);
	}

	public void MakeScoreSound ()
	{
		MakeSound (scoreSound);
	}

	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound (AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
