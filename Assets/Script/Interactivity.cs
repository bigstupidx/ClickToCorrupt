using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactivity : MonoBehaviour {

    
    public float[] price;
    public float dinheiro;
    public Click click;
    public UpgradeButtons up;
    public Button[] btn;

	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void Update()
    {
        dinheiro = click.money;

        for (int i = 0; i < btn.Length; i++)
        //{
            price[i] = up.custo[i];
            /*if (dinheiro < up.custo[i])
            {
                btn[i].interactable = false;
            }
            else
            {
                btn[0].interactable = true;

            }
        }*/

        SetInteractibility(1);
        SetInteractibility(2);
        SetInteractibility(3);
        SetInteractibility(4);
        SetInteractibility(5);
        SetInteractibility(6);
        SetInteractibility(7);
        SetInteractibility(8);
        SetInteractibility(9);
        SetInteractibility(10);
        SetInteractibility(11);
        SetInteractibility(12);
        SetInteractibility(13);
        SetInteractibility(14);
        SetInteractibility(15);
    }

    private void SetInteractibility(int num)
    {
        if (dinheiro >= price[num])
            btn[num].interactable = true;
        else
            btn[num].interactable = false;
    }
}
