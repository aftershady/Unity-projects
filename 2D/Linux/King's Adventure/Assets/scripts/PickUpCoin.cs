using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip pickCoinSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player tag enter in coin
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(pickCoinSound, transform.position);
            //add one coin to the singleton inventory
            Inventory.instance.AddCoins(1);
            //destroy the coin
            Destroy(gameObject);
        }
    }
}
