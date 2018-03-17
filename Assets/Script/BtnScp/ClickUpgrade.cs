using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUpgrade : MonoBehaviour
{

    [Header("Descrição")]

    
    public Text itemPrice;
    public Text itemLevel;
  




    public Click click;
    //public Click clickMps;
    public float custo;
    public int level;
    private float baseCost;
    float saveTimer = 0.0f;
    public Button btn;
    // Use this for initialization
    void Start()
    {

        baseCost = custo;

        custo = PlayerPrefs.GetFloat("custoclick", custo);
        level = PlayerPrefs.GetInt("levelclick", level);


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("w"))
        {

            PlayerPrefs.DeleteAll();
        }

        if (click.money < custo)
        {

            btn.interactable = false;

        }

        else
        {
            btn.interactable = true;
        }

        
        itemLevel.text = "Lv. " + level.ToString();
        itemPrice.text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo, false, false);
       



    }

    public void OnBuy()
    {

        if (click.money >= custo)
        {


            click.money -= custo;

            level += 1;

            click.mpc = click.mpc * 2;


            custo = custo * 2.50f;



            PlayerPrefs.SetFloat("custoclick", custo);
            PlayerPrefs.SetInt("levelclick", level);




        }
    }

    public void Deletar()
    {



        PlayerPrefs.DeleteAll();

        level = 0;
        custo = 5;



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
