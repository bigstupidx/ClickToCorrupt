using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caneta : MonoBehaviour {

	[Header("Descrição")]

	
	public Text itemPrice;
	public Text itemLevel;
	




	public Click click;
	//public Click clickMps;
	public float custo;

	public int level;
	public string itemName;
	private float baseCost;
    float saveTimer = 0.0f;
    public Button btn;
	// Use this for initialization
	void Start () {

		baseCost = custo;

		custo = PlayerPrefs.GetFloat ("custocaneta", custo);
		level = PlayerPrefs.GetInt ("levelcaneta", level);

	}

	// Update is called once per frame
	void Update () {

        if (click.money < custo)
        {

            btn.interactable = false;

        }

        else
        {
            btn.interactable = true;
        }

        //itemCPS.text = "+" + imps+" $" +"/seg";
		itemLevel.text = "Level. " + level.ToString ();
		itemPrice.text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo, false, false);
		//itemInfo.text = itemName;



	}

	public void OnBuy () {

		if (click.money >= custo) {


			click.money -= custo;

			level += 1;

			//click.mps = click.mps + imps;


            custo = custo * 1.20f;

			






		}
	}

	public void Deletar () {



		PlayerPrefs.DeleteAll ();

		level = 0;
		custo = 30;



	}

	/*public void OnCPSBuy () {


		if (click.money >= custo) {


			click.money -= custo;

			level += 1;

			click.mpc = click.mpc + 1;


			custo = (baseCost + Mathf.Pow (1.20f, level));



		}
			
	}*/
}
