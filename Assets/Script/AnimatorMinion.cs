using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorMinion : MonoBehaviour {

	public enum MinionStyle{
		Text, Image
	}

	public MinionStyle minionStyle;

	public float speedAnim , smoothTime, variableF;
	public Image img_ToBeAnimmed;
	public Text txt_ToBeAnimmed;
	public Click click;
    public Image img;

	// Use this for initialization
	void Start () {
		click = GameObject.FindObjectOfType<Click> ();

		if (minionStyle == MinionStyle.Image)
            img_ToBeAnimmed.rectTransform.localEulerAngles = new Vector3(0, 0, Random.Range(30,-30));
        else
			txt_ToBeAnimmed.text = "+" + click.mpc.ToString("F0");

        if(minionStyle == MinionStyle.Image)
            img.rectTransform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
	}
	
	// Update is called once per frame
	void Update () {
        if (minionStyle == MinionStyle.Image)
            Anims(img_ToBeAnimmed);
        else
        {
            AnimsTXT(txt_ToBeAnimmed);
            variableF -= Time.deltaTime * 8;
        }


    }

	public void Anims(Image img){
		float noise = Random.Range (-10, 10);

		img.rectTransform.Translate (0 * Time.deltaTime, - speedAnim * Time.deltaTime, 0);

		if (variableF >= 30)
			variableF -= Time.deltaTime * smoothTime;
		if (variableF < 80) {
			speedAnim = speedAnim += Time.deltaTime * 30;
			//img.CrossFadeAlpha (0, 5f, true);
		}

		//img.rectTransform.localEulerAngles = new Vector3 (0, 0, noise);
		Destroy (img.gameObject, 3.5f);
	}

	public void AnimsTXT(Text txt){
		float noise = Random.Range (-1, 1) * 100;

		txt.transform.Translate (0 * Time.deltaTime, speedAnim * Time.deltaTime, 0);

		if (variableF >= 30)
			variableF -= Time.deltaTime * smoothTime;
		if (variableF < 80) {
			speedAnim = speedAnim += Time.deltaTime * 30;
			txt.CrossFadeAlpha (0, 1, true);
		}

		txt.rectTransform.sizeDelta = new Vector2 (variableF, variableF);
		Destroy (txt.gameObject, 1.0f);
	}
}
