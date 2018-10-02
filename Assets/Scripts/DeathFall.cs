using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathFall : MonoBehaviour
{

   

    private IEnumerator DeathPause;
   
    private string SceneName;


    // Use this for initialization
    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene(); //aceder as propriedades da scene activa
       
        SceneName = activeScene.name;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        DeathPause = WaitToLoad(1.0f);
        
        
        StartCoroutine(DeathPause);
        


    }
    private IEnumerator WaitToLoad (float DeathPause)
    {
        Debug.Log("DEAD!");
        Time.timeScale /= 3;
        
        yield return new WaitForSeconds(DeathPause);
        
        SceneManager.LoadScene(SceneName);

        Debug.Log(SceneName);
        Time.timeScale = 1;
    }

   


}
