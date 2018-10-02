using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour {

    [Header("Linkage")]
    [SerializeField] private Text DeathCounter;
    [SerializeField] private Text CoinCounter;
    [SerializeField] private PopUp popUp;


    
    private int CoinDrop;
    private int Wallet;
    static bool CoinUpdate;


	// Use this for initialization
	void Start () {

        popUp.Close();
        CoinUpdate = CoinCollect.RenderEnable;


    }
	
	// Update is called once per frame
	void Update () {


      

    }

    public void OnOpenSettings()
    {
        popUp.Open();
    }



    public int WalletUpdate(int CoinDrop, int Wallet)
    {
   
        Wallet += CoinDrop;

        return Wallet;
    }

    public void WalletDisplay(int Wallet)
    {

        



    }

    public void OnGUI()
    {

        CoinCounter.text = Wallet.ToString();

    }
}
