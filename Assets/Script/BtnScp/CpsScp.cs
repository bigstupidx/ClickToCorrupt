using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CpsScp : MonoBehaviour {


	[Header("Descrição")]

	public Text itemInfo;
	public Text itemPrice;
	public Text itemLevel;
	public Text itemCPS;

	[Header("Descrição")]


	public Click click;
   
	//public Click clickMps;
	public float custoclick;
	public int levelclick;
	public string itemName = "Melhorar o Click";
	public int mpc = 1;
	private float baseCostclick;
	float saveTimer = 0.0f;
    public Button btn;

	// Use this for initialization
	void Start () {

		baseCostclick = custoclick;

		custoclick = PlayerPrefs.GetFloat ("custoclick", custoclick);
		levelclick = PlayerPrefs.GetInt ("levelclick", levelclick);

	}

    // Update is called once per frame
    void Update() {


        if (click.money < custoclick)
        {

            btn.interactable = false;

        }

        else {
            btn.interactable = true;
        }
        itemCPS.text = "+" + mpc.ToString()+" $" +"/click";
		itemLevel.text = "Level. " + levelclick.ToString ();
		itemPrice.text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custoclick, false, false);
		//itemInfo.text = itemName;



	}

	public void OnBuy () {

        if (click.money >= custoclick)
        {


            click.money -= custoclick;

            levelclick += 1;

            click.mpc =  click.mpc + mpc;


            custoclick = (baseCostclick + Mathf.Pow(1.20f, levelclick));


            PlayerPrefs.SetFloat("custoclick", custoclick);
            PlayerPrefs.SetInt("levelclick", levelclick);
        }

        

            


        


	} 


	public void Deletar () {



		PlayerPrefs.DeleteAll ();

		levelclick = 0;
		custoclick = 10;



	}

}
