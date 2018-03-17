using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialContador : MonoBehaviour {

    public TutorialSystem tutorialsystem;



    private void OnMouseDown()
    {
        tutorialsystem.tutorialContador++;
    }
}
