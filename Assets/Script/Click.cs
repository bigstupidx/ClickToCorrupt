using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [Header("Economia")]
    public float mpc;
    public float money;
    public float mps;
    public Button clickButton;

    [Header("Displays")]
    public Text moneyDisplay;
    public Text mpcDisplay;
    public Text mpsDisplay;
    public Text multipDisplay;

    [Header("Operadores")]
    float saveTimer = 0.0f;
    private float divisor = 0.275f;
    public float updateTime = 0.0f;
    float cronometro = 0.0f;
    int contador = 0;
    float counter = 0.0f;







    [Header("UI")]
    public GameObject plusMoney;
    public Image radial;
    private Color newColor;
    public Image fillRate;
    private float radialvelocidade;
    public float smooth = 0.5f;
    public float multiplier;
    public Animator clickAnimator;
    public GameObject blockGovernador;
    public GameObject blockPresidente;
    public GameObject blockPrefeito;
    public GameObject compradoPrefeito;
    public GameObject compradoGovernador;
    public GameObject compradoPresidente;
    public GameObject compradoCasa;
    public GameObject compradoApartamento;
    public GameObject compradoMansao;
    public GameObject compradoBanco;
    public GameObject compradoCastelo;
    public GameObject compradoCassino;


    [Header("Imóveis")]
    public bool level7;
    public bool level6;
    public bool level5;
    public bool level4;
    public bool level3;
    public bool level2;
    public bool level1 = true;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public Button btn6;
    public Button btn7;

    [Header("Cargos")]
    public bool prefeito = true;
    public bool governador = true;
    public bool presidente = true;

    public Button btnPrefeito;
    public Button btnGovernador;
    public Button btnPresidente;

    [Header("Outros")]
    public Button deletar;
    public float mpcSec;
    private float result;
    public bool clicked;
    private float meuDeusDeuCerto;
    float tempTime = 5;
    public float maxMultiplier;






    // Use this for initialization
    void Start()
    {

        radialvelocidade = 1;

        //money = PlayerPrefs.GetFloat("Money_Data");
        if (!PlayerPrefs.HasKey("Reset1"))
        {
            Deletar();
            PlayerPrefs.SetString("Reset1", "DL_Ok");
        }
        if (PlayerPrefs.HasKey("mpc_Data"))
            mpc = PlayerPrefs.GetFloat("mpc_Data");
        else
        {
            PlayerPrefs.SetFloat("mpc_Data", 1);
            mpc = PlayerPrefs.GetFloat("mpc_Data");
        }

        mps = PlayerPrefs.GetFloat("mps_Data");
        money = PlayerPrefs.GetFloat("money_Data");


        // radial.color = new Color32(255, 255, 255, 18);

        newColor = radial.color;

        SalvarBool();
    }


    public void SalvarBool()
    {
        level2 = (PlayerPrefs.GetInt("level2") != 0);
        level3 = (PlayerPrefs.GetInt("level3") != 0);
        level4 = (PlayerPrefs.GetInt("level4") != 0);
        level5 = (PlayerPrefs.GetInt("level5") != 0);
        level6 = (PlayerPrefs.GetInt("level6") != 0);
        level7 = (PlayerPrefs.GetInt("level7") != 0);

        prefeito = (PlayerPrefs.GetInt("prefeito") != 0);
        governador = (PlayerPrefs.GetInt("governador") != 0);
        presidente = (PlayerPrefs.GetInt("presidente") != 0);

        /* casa = (PlayerPrefs.GetInt("casa") != 0);
         apartamento = (PlayerPrefs.GetInt("apartamento") != 0);
         mansao = (PlayerPrefs.GetInt("mansao") != 0);
         banco = (PlayerPrefs.GetInt("banco") != 0);
         castelo = (PlayerPrefs.GetInt("castelo") != 0);
         cassino = (PlayerPrefs.GetInt("cassino") != 0);*/


    }
    public float counterX;

    public void Comprado()


    {
        //Upgrade panel

        if (prefeito == false)
        {
            blockPrefeito.SetActive(true);


        }

        else
        {

            blockPrefeito.SetActive(false);
        }

        if (governador == false)
        {
            blockGovernador.SetActive(true);


        }

        else
        {

            blockGovernador.SetActive(false);
        }

        if (presidente == false)
        {
            blockPresidente.SetActive(true);


        }

        else
        {

            blockPresidente.SetActive(false);
        }

        //Limit Button

        if (prefeito == false)
        {
            compradoPrefeito.SetActive(false);


        }

        else
        {

            compradoPrefeito.SetActive(true);
        }



        if (governador == false)
        {
            compradoGovernador.SetActive(false);


        }

        else
        {

            compradoGovernador.SetActive(true);
        }

        if (presidente == false)
        {
            compradoPresidente.SetActive(false);
        }

        else
        {

            compradoPresidente.SetActive(true);
        }

        if (level2 == false)
        {
            compradoCasa.SetActive(false);


        }

        else
        {

            compradoCasa.SetActive(true);
        }

        if (level3 == false)
        {
            compradoApartamento.SetActive(false);


        }

        else
        {

            compradoApartamento.SetActive(true);
        }

        if (level4 == false)
        {
            compradoMansao.SetActive(false);


        }

        else
        {

            compradoMansao.SetActive(true);
        }

        if (level5 == false)
        {
            compradoBanco.SetActive(false);


        }

        else
        {

            compradoBanco.SetActive(true);
        }

        if (level6 == false)
        {
            compradoCastelo.SetActive(false);


        }

        else
        {

            compradoCastelo.SetActive(true);
        }

        if (level7 == false)
        {
            compradoCassino.SetActive(false);


        }

        else
        {

            compradoCassino.SetActive(true);
        }

    }

    public void btnMoney()
    {



        money = +10000000;


    }
    // Update is called once per frame
    void Update()
    {

 


        Comprado();

        ColorChanging();

        CargosLimitador();



        if (Input.GetKeyDown("m"))
        {

            money = +10000000;

        }



        if (Input.GetKeyDown("w"))
        {

            PlayerPrefs.DeleteAll();
        }


        //mpc = +mpc * multiplier;
        PlayerPrefs.SetFloat("mpc_Data", mpc);
        PlayerPrefs.SetFloat("mps_Data", mps);
        PlayerPrefs.SetFloat("money_Data", money);


        fillRate.fillAmount = multiplier / maxMultiplier;
        //print(multiplier);
        if (fillRate.fillAmount > 0)
        {


            multipDisplay.text = (multiplier.ToString("F0") + "x").ToString();


        }
        else
        {

            multipDisplay.text = null;

        }


        if (multiplier > 1)
        {
            multiplier -= Time.deltaTime / 5;
        }
        else
        {
            multiplier = 1;
        }

        if (counterX > 0)
            counterX -= Time.deltaTime;
        else
            multiplier -= Time.deltaTime * 3;


        if (fillRate.fillAmount <= 0.2f)
        {
            fillRate.CrossFadeAlpha(0, 0.5f, false);
            multipDisplay.text = null;

        }
        else
        {
            fillRate.CrossFadeAlpha(1, 0, false);
            multipDisplay.text = (multiplier.ToString("F0") + "x").ToString();

        }
        radial.transform.Rotate(0, 0, 10 * Time.deltaTime * radialvelocidade);

        LimitadorInteragivel();

        meuDeusDeuCerto = mps + mpcSec;


        //float tempTime = 1.0f;
        if (clicked)
        {
            if (tempTime > 0)
            {
                tempTime -= Time.deltaTime;

                //Para cada click dentro de 1 seg o mpcSec aumenta =+ mpc
                mpcSec = +mpc;
            }

            if (tempTime <= 0)
            {
                mpcSec = 0.0f;
                clicked = false;
                tempTime = 1;
            }
        }
        else
        {
            tempTime = 1;
        }










        /*saveTimer += 1.0f * Time.deltaTime;
		if (saveTimer > 05.0f) {
			Salvar ();
			saveTimer = 0.0f;
		}*/



        moneyDisplay.text = "$" + CurrencyConverter.Instance.GetCurrencyIntoString(money, false, false);
        mpcDisplay.text = CurrencyConverter.Instance.GetCurrencyIntoString(mpc, false, true) + "$/C";
        mpsDisplay.text = CurrencyConverter.Instance.GetCurrencyIntoString(mps, true, false) + "$/s";





        if (level1 && money <= 1000000)
        {



            if (counter < updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }

        }

        if (level2 && money <= 5000000)
        {



            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }

        if (level3 && money <= 15000000)
        {



            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }

        if (level4 && money <= 45000000)
        {



            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }

        if (level5 && money <= 100000000)
        {



            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }

        if (level6 && money <= 500000000)
        {



            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }

        if (level7)
        {





            if (counter <= updateTime)
                counter += Time.deltaTime;
            else
            {

                money += mps * updateTime / divisor;
                counter = 0;
            }


        }
    }



    public void botaoOnclick()
    {

        if (multiplier < maxMultiplier)
            multiplier += 0.05f;

        counterX = 1;
        //contador = contador + 1;
        MinionInstance();
        clicked = true;
        tempTime = 1;
        cronometro = 0;
        /*GameObject plusM = (GameObject)	Instantiate (plusMoney, position, Quaternion.identity);*/
        clickButton.image.rectTransform.sizeDelta = new Vector2(332, 207);
        MetodoMPC();
        //Deletar();
    }


    public void botaoOutclick()
    {

        clickButton.image.rectTransform.sizeDelta = new Vector2(340, 215);


        //money += moneyPerClick;



    }
    /*public void Salvar () {

		


	}*/

    public UpgradeButtons up;

    public void Deletar()
    {
        PlayerPrefs.DeleteAll();
        money = 0;
        mps = 0;
        mpc = 1;

        up.custo[0] = 0;
        up.custo[1] = 30;
        up.custo[2] = 100;
        up.custo[3] = 1000;
        up.custo[4] = 10000;
        up.custo[5] = 50000;
        up.custo[6] = 200000;
        up.custo[7] = 500000;
        up.custo[8] = 1000000;
        up.custo[9] = 5000000;
        up.custo[10] = 30000000;
        up.custo[11] = 70000000;
        up.custo[12] = 200000000;
        up.custo[13] = 400000000;
        up.custo[14] = 600000000;
        up.custo[15] = 1000000000;

        up.DeleteKeys();

    }
    public void MetodoMPC()
    {





        if (level1 && money <= 1000000)
        {



            money += mpc;

        }

        if (level2 && money <= 5000000)
        {



            money += mpc;


        }

        if (level3 && money <= 15000000)
        {



            money += mpc;


        }

        if (level4 && money <= 45000000)
        {



            money += mpc;


        }

        if (level5 && money <= 100000000)
        {



            money += mpc;


        }

        if (level6 && money <= 500000000)
        {



            money += mpc;


        }

        if (level7)
        {



            money += mpc;


        }









    }

    public Transform[] positionMinion;
    public Transform[] positionMinionImg;

    public GameObject[] minionPrefab;

    public void MinionInstance()
    {
        //Random.Range(0, positionMinion.Length);


        int rP = Random.Range(0, positionMinion.Length);
        int rMP = Random.Range(0, minionPrefab.Length);
        int instant = Random.Range(1, 4);
        print(instant);

        GameObject tempMinion = Instantiate(minionPrefab[0], positionMinion[rP].position, positionMinion[rP].rotation) as GameObject;
        if (instant > 2)
        {
            GameObject tempMinion2 = Instantiate(minionPrefab[1], positionMinionImg[rP].position, positionMinionImg[rP].rotation) as GameObject;
            tempMinion2.transform.SetParent(positionMinionImg[rP]);
        }
        tempMinion.transform.SetParent(positionMinion[rP]);




    }







    public void OnClick1()
    {

        level1 = true;



    }

    public void OnClick2()
    {

        level2 = true;

        money = money - 1000000;
        PlayerPrefs.SetInt("level2", (level2 ? 1 : 0));

    }

    public void OnClick3()
    {

        level3 = true;

        money = money - 5000000;
        PlayerPrefs.SetInt("level3", (level3 ? 1 : 0));
    }

    public void OnClick4()
    {

        level4 = true;
        money = money - 15000000;
        PlayerPrefs.SetInt("level4", (level4 ? 1 : 0));
    }

    public void OnClick5()
    {

        level5 = true;
        money = money - 45000000;
        PlayerPrefs.SetInt("level5", (level5 ? 1 : 0));
    }

    public void OnClick6()
    {

        level6 = true;

        money = money - 100000000;

        PlayerPrefs.SetInt("level6", (level6 ? 1 : 0));
    }

    public void OnClick7()
    {

        level7 = true;

        money = money - 500000000;

        PlayerPrefs.SetInt("level3", (level7 ? 1 : 0));
    }

    public void OnClickPrefeito()
    {
        prefeito = true;

        money = money - 10;

        PlayerPrefs.SetInt("prefeito", (prefeito ? 1 : 0));
    }

    public void OnClickGovernador()
    {
        governador = true;

        money = money - 75000;

        PlayerPrefs.SetInt("governador", (governador ? 1 : 0));
    }

    public void OnClickPresidente()
    {

        presidente = true;

        money = money - 10000000;

        PlayerPrefs.SetInt("presidente", (presidente ? 1 : 0));

    }



    public void LimitadorInteragivel()
    {


        if (money < 1000000)
        {

            btn2.interactable = false;

        }

        else
        {
            if (level2)

                btn2.interactable = false;

            else
            {

                btn2.interactable = true;
            }
        }








        if (money < 5000000)
        {

            btn3.interactable = false;

        }

        else
        {
            if (level3)

                btn3.interactable = false;

            else
            {

                btn3.interactable = true;
            }
        }













        if (money < 15000000)
        {

            btn4.interactable = false;

        }

        else
        {
            if (level4)

                btn4.interactable = false;

            else
            {

                btn4.interactable = true;
            }
        }










        if (money < 45000000)
        {

            btn5.interactable = false;

        }

        else
        {
            if (level5)

                btn5.interactable = false;

            else
            {

                btn5.interactable = true;
            }
        }


        if (money < 100000000)
        {

            btn6.interactable = false;

        }

        else
        {
            if (level6)

                btn6.interactable = false;

            else
            {

                btn6.interactable = true;
            }
        }



        if (money < 500000000)
        {

            btn7.interactable = false;

        }

        else
        {
            if (level7)

                btn7.interactable = false;

            else
            {

                btn7.interactable = true;
            }
        }

    }

    public void CargosLimitador()
    {


        if (money < 10)
        {

            btnPrefeito.interactable = false;

        }

        else
        {
            if (prefeito)

                btnPrefeito.interactable = false;

            else
            {

                btnPrefeito.interactable = true;
            }
        }

        if (money < 75000)
        {

            btnGovernador.interactable = false;

        }

        else
        {
            if (governador)

                btnGovernador.interactable = false;

            else
            {

                btnGovernador.interactable = true;
            }
        }

        if (money < 10000000)
        {

            btnPresidente.interactable = false;

        }

        else
        {
            if (presidente)

                btnPresidente.interactable = false;

            else
            {

                btnPresidente.interactable = true;
            }
        }


    }






    public void ColorChanging()
    {
        Color mt2 = new Color32(100, 220, 255, 50);
        Color mt3 = new Color32(100, 255, 120, 50);
        Color mt4 = new Color32(240, 255, 100, 60);
        Color original = new Color32(255, 255, 255, 40);




        if (multiplier >= 4)
        {

            newColor = mt4;
            radialvelocidade = 6;
            clickAnimator.speed = 2.5f;
        }

        else if (multiplier >= 3)
        {
            radialvelocidade = 5;
            newColor = mt3;
            clickAnimator.speed = 2;
        }

        else if (multiplier >= 2)
        {
            radialvelocidade = 3;
            newColor = mt2;
            clickAnimator.speed = 1.5f;
        }

        else
        {
            newColor = original;
            radialvelocidade = 1;
            clickAnimator.speed = 1;
        }





        radial.color = Color.Lerp(radial.color, newColor, Time.deltaTime * smooth);
        //clickAnimator.speed = 


    }


}




