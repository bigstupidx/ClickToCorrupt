using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{

    public AudioSource audioPerClick, audioPerMomment, audioMenu, buyAudio, music;
    public int turnClick;
    public int counter;
    public Image btnSoundControl;
    public Sprite btnOn;
    public Sprite btnOff;
    public bool asd;


    void Start()
    {

        //btnSoundControl.sprite = btnOn;
        //SoundControl();

        counter = PlayerPrefs.GetInt("SALVESALVE");

    }


    void Update()
    {
        if (turnClick > 50)
        {;
            turnClick = 0;
            Emit_Sound_Temp();
        }

        SoundUpdate();

    }

    public void Emit_Sound_Btn()
    {
        turnClick++;
        audioPerClick.Play();

    }

    public void Emit_Sound_Temp()
    {
        audioPerMomment.Play();

    }

    public void SoundControl()
    {
        counter++;
        if (counter == 2)
            counter = 0;

        PlayerPrefs.SetInt("SALVESALVE", counter);
    }


    private void SoundUpdate()
    {
        if (counter == 1)
        {
            audioPerClick.mute = true;
            audioPerMomment.mute = true;
            audioMenu.mute = true;
            buyAudio.mute = true;
            music.mute = true;

            btnSoundControl.sprite = btnOff;
        }

        if (counter == 0)
        {
            audioPerClick.mute = false;
            audioPerMomment.mute = false;
            audioMenu.mute = false;
            buyAudio.mute = false;
            music.mute = false;

            btnSoundControl.sprite = btnOn;
        }
    }



}
