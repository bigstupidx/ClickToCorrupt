using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : MonoBehaviour {

    public GameObject mainTutorial;
    public GameObject primeira;
    public GameObject segunda;
    public GameObject terceira;
    public GameObject quarta;
    public bool tutorial = true;
    public int tutorialContador;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Tuto4"))
        {
            PlayerPrefs.SetInt("Tuto4", 1);
            //PlayerPrefs.DeleteKey("Tuto1");
            tutorial = true;
        }
        else
        {
            tutorial = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (tutorial == true)
        {
            mainTutorial.active = true;
        }

        if (tutorialContador == 1)
        {

            segunda.active = true;
            primeira.active = false;
        }

        if (tutorialContador == 2)
        {

            terceira.active = true;
            segunda.active = false;
        }

        if (tutorialContador == 3)
        {

            quarta.active = true;
            terceira.active = false;
        }

        if (tutorialContador >= 4)
        {

            quarta.active = false;
            terceira.active = false;
            mainTutorial.active = false;
            tutorial = false;           
           
        }

    }

    public void onClick()
    {
        tutorialContador++;
    }


}
