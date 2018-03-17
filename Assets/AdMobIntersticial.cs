using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AdMobIntersticial : MonoBehaviour
{



    void Start()
    {
        //Request Ad
        RequestInterstitialAds();
    }

    void Update()
    {
        RequestInterstitialAds();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showInterstitialAd();
            //Application.Quit();
        }
    }

    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            

            Debug.Log("SHOW AD XXX");
        }

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
    

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd("ca-app-pub-1120115677806043~7935499225");

        //***Test***
       /* AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       .Build();*/

        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
       // interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
   /* private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        Application.Quit();

    }*/
}

    


  

    

