using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    //counter of coins
    public int coinsCount;
    //text who display number of coins
    public Text coinsCountText;
    //create singleton
    public static Inventory instance;

    private void Awake()
    {
        //if multiple call of singleton, result and error
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance Inventory");
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        //add number of coins send to the coinsCount
        coinsCount += count;
        //send the coinsCount to the canva to display is, convert int in string
        coinsCountText.text = coinsCount.ToString();
    }

}
