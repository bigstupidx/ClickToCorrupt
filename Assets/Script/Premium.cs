using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Premium : MonoBehaviour {


    public bool premium;
    public Image[] imgs;
    public Image[] imgsDark;
    public SpriteRenderer bg;
    public Image bar;
    public Text multipTxt;
    public Text[] txts;
    public Color pm_Img, pm_ImgDark, golden, fontColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (premium)
        {
            for(int i = 0; i < imgs.Length; i++)
            {
                imgs[i].color = pm_Img;
                bg.color = pm_Img;

            }

            for (int i = 0; i < imgsDark.Length; i++)
            {
                imgsDark[i].color = pm_ImgDark;
            }

            for (int i = 0; i < txts.Length; i++)
            {
                txts[i].color = fontColor;
            }
                bar.color = golden;
            multipTxt.color = golden;
        }
	}
}
