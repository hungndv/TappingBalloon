using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsUnityPluginScript : MonoBehaviour
{
	public BannerView bannerView;

	void Awake ()
	{
		RequestBanner ();
		bannerView.Show ();
	}

	/*
	void OnGUI()
	{
		//bannerView.Show();
		//bannerView.Hide();
		//bannerView.Destroy();
	}
	*/

	void OnDestroy()
	{
		bannerView.Destroy();
	}

	#region ads

	private void RequestBanner ()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-6374251763846960/4309275532";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView (adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Register for ad events.
		bannerView.AdLoaded += HandleAdLoaded;
		bannerView.AdFailedToLoad += HandleAdFailedToLoad;
		bannerView.AdOpened += HandleAdOpened;
		bannerView.AdClosing += HandleAdClosing;
		bannerView.AdClosed += HandleAdClosed;
		bannerView.AdLeftApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd (createAdRequest ());
	}
	
	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest ()
	{
		return new AdRequest.Builder ()
			.AddTestDevice (AdRequest.TestDeviceSimulator)
				.AddTestDevice ("3E5D0101725F4CE4")
				.AddKeyword ("game")
				.SetGender (Gender.Male)
				.SetBirthday (new DateTime (1985, 1, 1))
				.TagForChildDirectedTreatment (false)
				.AddExtra ("color_bg", "9B30FF")
				.Build ();
		
	}
	
	public void HandleAdLoaded (object sender, EventArgs args)
	{
		print ("HandleAdLoaded event received.");
	}
	
	public void HandleAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		print ("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
	
	public void HandleAdOpened (object sender, EventArgs args)
	{
		print ("HandleAdOpened event received");
	}
	
	void HandleAdClosing (object sender, EventArgs args)
	{
		print ("HandleAdClosing event received");
	}
	
	public void HandleAdClosed (object sender, EventArgs args)
	{
		print ("HandleAdClosed event received");
	}
	
	public void HandleAdLeftApplication (object sender, EventArgs args)
	{
		print ("HandleAdLeftApplication event received");
	}
	
	#endregion
}
