using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colchão : MonoBehaviour {

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
	float saveTimer = 0.0f;
    public Button btn;

	// Use this for initialization
	void Start () {

       

        baseCost = custo;

		custo = PlayerPrefs.GetFloat ("custocolchao", custo);
		level = PlayerPrefs.GetInt ("levelcolchao", level);

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

        itemCPS.text = "+" + imps+" $" +"/seg";
		itemLevel.text = "Level: " + level.ToString ();
		itemPrice.text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo, false, false);
		itemInfo.text = itemName;



	}

	public void OnBuy () {

		if (click.money >= custo) {


			click.money -= custo;

			level += 1;

			click.mps = click.mps + imps;


			custo = (baseCost + Mathf.Pow (1.20f, level));

			PlayerPrefs.SetFloat ("custocolchao", custo);
			PlayerPrefs.SetInt ("levelcolchao", level);






		}
	}

	public void Deletar () {



		PlayerPrefs.DeleteAll ();

		level = 0;
		custo = baseCost;



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
