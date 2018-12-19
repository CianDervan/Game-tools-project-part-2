using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Celebration : MonoBehaviour {

    public Canvas myCanvas;

    private void Start()
    {
        myCanvas.enabled = false;
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "box")
        {
            myCanvas.enabled = true;
        }
    }





}
