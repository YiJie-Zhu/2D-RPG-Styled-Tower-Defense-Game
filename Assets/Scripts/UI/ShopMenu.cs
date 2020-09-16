using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;

    public Texture2D arrowCursor;
   public void CloseShop()
    {
        if (PlayerBow.isBow)
        {
            Cursor.SetCursor(arrowCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }
        gameObject.SetActive(false);
    }

    public void BuyArrow()
    {
        if(CoinManager.coin >= 20)
        {
            PlayerBow.arrows++;
            CoinManager.coin -= 20;
        }
        
    }
    public void BuyBow()
    {
        if(CoinManager.coin >= 100)
        {
            bow.SetActive(true);
            CoinManager.coin -= 100;
        }
        
    }

    public void BuySword()
    {
        if (CoinManager.coin >= 150)
        {
            CoinManager.coin -= 150;
            sword.SetActive(true);
        }
        
    }

    public void BuyPotion()
    {
        if(CoinManager.coin >= 50)
        {
            CoinManager.coin -= 50;
            HealthPot.numPot++;
        }
    }
}

