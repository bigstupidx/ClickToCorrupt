using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cronometro : MonoBehaviour {

	public float relogio = 0.0f;
	public Text txt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		relogio = relogio + Time.deltaTime;

		txt.text = relogio.ToString ("F");
		
	}
}
