using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : UIController {

    private SpriteRenderer _CoinRender;

    //  public int CoinCounter;
    
    public static int TotalDrop;
    public static bool RenderEnable = true;
    //  public static int coinPurse=0;
        


    void Start() {

        _CoinRender = GetComponent<SpriteRenderer>();
        TotalDrop = 0;

        

    }

    // Update is called once per frame
    void Update() {



    }

    public void OnTriggerEnter2D(Collider2D CoinCatch)
    {
 
        if (_CoinRender.enabled)
        {
            CoinDrop();
            _CoinRender.enabled = false;
            RenderEnable = false;
            Debug.Log(TotalDrop);
        }

    }

    private void CoinDrop()
    {

        int dropProb = Random.Range(0, 100);
       Debug.Log(dropProb);
        if (dropProb > 0 && dropProb < 70)
        {
            TotalDrop = Random.Range(15, 110);
        }
        else if (dropProb >= 70 && dropProb < 90)
        {
            TotalDrop = Random.Range(100, 301);
        }
        else if (dropProb >= 90 && dropProb < 97)
        {
            TotalDrop = Random.Range(251, 500);
        }
        else if (dropProb >= 97 && dropProb < 100)
        {
            TotalDrop = Random.Range(456, 1000);
        }

        

    }



}
