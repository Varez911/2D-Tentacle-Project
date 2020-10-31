using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScore : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D coinobj)
    {
        if (coinobj.gameObject.CompareTag("Coin"))
        {
            Destroy(coinobj.gameObject);
            uiCoin.scoremanager.UpdateSCore(1);
        }

        if (coinobj.gameObject.CompareTag("Gem"))
        {
            Destroy(coinobj.gameObject);
            uiCoin.scoremanager.UpdateSCore(10);
        }
    }
}
