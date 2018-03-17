using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour {

    public Click click;
    public Button doublemps;
    public Button instantmoney;
    public Button doublemoney;
    public float counter;
    bool rodando = false;


    public void ShowRewardedAdDoubleMps()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultDoubleMps };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResultDoubleMps(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //Recompensa
                DoubleMps();

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }


    public void ShowRewardedAdInstantMoney()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultInstantMoney };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResultInstantMoney(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //Recompensa
                InstantMoney();

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void ShowRewardedAdDoubleMoney()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultDoubleMoney };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResultDoubleMoney(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //Recompensa
                DoubleMoney();

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }




    void Update()
    {
        if (rodando == true)
        {

            counter -= Time.deltaTime;
        }

        if (counter < 0)
        {
            click.mps = click.mps / 2;
            counter = 30.0f;
            rodando = false;
        }

    }

    public void DoubleMps()
    {
        rodando = true;




        if (counter >= 0)
        {
            click.mps = click.mps * 2;

        }






    }

    public void InstantMoney()
    {

        click.money = click.money + click.money * 0.5f;


    }

    public void DoubleMoney()
    {

        click.money = click.money * 2;

    }

	
    
}
