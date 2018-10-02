using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    [SerializeField] private Slider speedSlider;

    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
        
    }


    public void Open(){
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }

    public void OnSubmission(string text)
    {

        Debug.Log(text);

    }
    public void OnSpeedChange(float speed)
    {
        Debug.Log("Speed: " + speed);
        PlayerPrefs.SetFloat("speed", speed);
    }



}
