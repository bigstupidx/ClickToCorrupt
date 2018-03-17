using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour {

    public Click click;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnClick1() {

        click.level1 = true;

        
    }

    public void OnClick2() {

        click.level2 = true;
    }

    public void OnClick3()
    {

        click.level3 = true;
    }

    public void OnClick4()
    {

        click.level4 = true;
    }

    public void OnClick5()
    {

        click.level5 = true;
    }

    public void OnClick6()
    {

        click.level6 = true;
    }
}
