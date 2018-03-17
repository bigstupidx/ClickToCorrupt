using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour {

    public Click click;
    public bool original = false;
    


    
    public string tipoPowerUp;
    public int indice_Mod;
    [Header("Setup")]
    public Text[] txt_Custo, txt_Level;
    public float[] custo;
    public int[] level;
    public Button[] btn;

    

    //public Enum Btn;
   // public string[] saveName;

    public  bool checkGetValue;
    // Use this for initialization
    void Start () {

        if (!PlayerPrefs.HasKey("PrimeiraVez"))
        {
            for (int i = 0; i < txt_Custo.Length; i++)
            {
                indice_Mod = i;
                PlayerPrefs.SetFloat(indice_Mod + "_Cost", custo[i]);
                txt_Custo[i].text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo[i], false, false);
            }
            PlayerPrefs.SetInt("PrimeiraVez", 1);
        }



        for (int i = 0; i < txt_Custo.Length; i++)
        {
            indice_Mod = i;
            custo[i] = PlayerPrefs.GetFloat(indice_Mod + "_Cost");
        }

        for (int i = 0; i < txt_Level.Length; i++)
        {
            indice_Mod = i;
            level[i] = PlayerPrefs.GetInt(indice_Mod + "_Level");
            txt_Level[i].text = "Lv. " + level[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            PlayerPrefs.DeleteAll();
        }

        for (int i = 0; i < txt_Custo.Length; i++)
        {
            indice_Mod = i;
            PlayerPrefs.SetFloat(indice_Mod + "_Cost", custo[i]);
            txt_Custo[i].text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo[i], false, false);
        }

        for (int i = 0; i < txt_Level.Length; i++)
        {            
            indice_Mod = i;
            level[i] = PlayerPrefs.GetInt(indice_Mod + "_Level");
            txt_Level[i].text = "Lv. " + level[i].ToString();                      
        }

       /* if (!checkGetValue)
        {
            
            for (int i = 0; i < txt_Level.Length; i++)
            {
                if (PlayerPrefs.HasKey(indice_Mod + "_Level"))
                {
                    indice_Mod = i;
                    level[i] = PlayerPrefs.GetInt(indice_Mod + "_Level");
                    txt_Level[i].text = "Lv. " + level[i].ToString();
                }
                else
                {
                    indice_Mod = i;
                    PlayerPrefs.SetInt(indice_Mod + "_Level", 0);
                    txt_Level[i].text = "Lv. " + level[i].ToString();
                }
            }

            checkGetValue = true;
            // indice_Mod + "_Level"
        }*/     
    }

    public void DeleteKeys()
    {
        for (int i = 0; i < txt_Custo.Length; i++)
        {
            indice_Mod = i;
            PlayerPrefs.SetFloat(indice_Mod + "_Cost", custo[i]);
        }
    }

    public void SetAction(string act)
    {
        tipoPowerUp = act;
    }

    public void SetIndex(int indx)
    {
        indice_Mod = indx;
        onClick(indice_Mod);

    }

    void onClick(int idc)
    {
        if (idc == 0)
        {
            print("Indice Inválido");
            print("O custo será igual à 0, custo[idc]; idc = 0");
        }

       
        
        click.money -= custo[idc];
        PlayerPrefs.SetFloat("Money_Data", click.money);
        custo[indice_Mod] = custo[indice_Mod] * 1.15f;
        txt_Custo[indice_Mod].text = "$ " + CurrencyConverter.Instance.GetCurrencyIntoString(custo[indice_Mod], false, false);
        


        if (custo [indice_Mod]> click.money)
        {
            btn[indice_Mod].interactable = false;
        }

        else
        {
            btn[indice_Mod].interactable = true;
        }

        if (idc == 1)
        {
            click.mps += 0.3f;
        }

        if (idc == 2)
        {
            click.mps += 1.0f;
        }

        if (idc == 3)
        {
            click.mps += 3.5f;
        }

        if (idc == 4)
        {
            click.mps += 6.1f;
        }

        if (idc == 5)
        {
            click.mps += 20.0f;
        }

        if (idc == 6)
        {
            click.mps += 40.0f;
        }

        if (idc == 7)
        {
            click.mps += 70.0f;
        }

        if (idc == 8)
        {
            click.mps += 300.0f;
        }

        if (idc == 9)
        {
            click.mps += 1500.0f;

        }

        if (idc == 10)
        {
            click.mps += 3000.0f;
        }

        if (idc == 11)
        {
            click.mps += 5000.0f;
        }

        if (idc == 12)
        {
            click.mps += 8000.0f;
        }

        if (idc == 13)
        {
            click.mps += 15000.0f;
        }

        if (idc == 14)
        {
            click.mps += 20000.0f;
        }

        if (idc == 15)
        {
            click.mps += 50000.0f;
        }

        level[idc]++;
        txt_Level[idc].text = "Lv. " + level[idc].ToString();

        string codeNameCost = indice_Mod + "_Cost";
        string codeNameLevel = indice_Mod + "_Level";

        PlayerPrefs.SetFloat(codeNameCost, custo[idc]);       
        PlayerPrefs.SetInt(codeNameLevel, level[idc]);
    }

    public void ValoresOriginais ()
    {       
        click.money = 0;
        click.mpc = 1;
        click.mps = 0;       
    }


    
}
