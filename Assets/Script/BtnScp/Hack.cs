using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hack : MonoBehaviour {

	[Header("Descrição")]

	public Text itemInfo;
	public Text itemPrice;
	public Text itemLevel;
	public Text itemCPS;




	public Click click;
	//public Click clickMps;
	public float custo;
	public float imps;
	public int level;
	public string itemName;
	private float baseCost;
    public Button btn;

	float saveTimer = 0.0f;
	// Use this for initialization
	void Start () {



        

        baseCost = custo;

		custo = PlayerPrefs.GetFloat ("custohack", custo);
		level = PlayerPrefs.GetInt ("levelhack", level);

	}

	// Update is called once per frame
	void Update () {

		itemCPS.text = "+" + imps+" $" +"/seg";
		itemLevel.text = "Level: " + level.ToString ();
		itemPrice.text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo, false, false);
		itemInfo.text = itemName;

        if (click.money < custo)
        {

            btn.interactable = false;

        }

        else
        {
            btn.interactable = true;
        }

    }

	public void OnBuy () {

		if (click.money >= custo) {


			click.money -= custo;

			level += 1;

			click.mps = click.mps + imps;


			custo = (baseCost + Mathf.Pow (1.20f, level));

			PlayerPrefs.SetFloat ("custohack", custo);
			PlayerPrefs.SetInt ("levelhack", level);






		}
	}


	public void Deletar () {



		PlayerPrefs.DeleteAll ();

		level = 0;
		custo = 1000000;



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
