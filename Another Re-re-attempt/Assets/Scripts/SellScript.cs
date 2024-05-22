using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellScript : MonoBehaviour
{
    private int RayCastLength = 2;
    public LayerMask mask;

    public BuyMechanic BuyScript;

    public MoneyManager MoneyScript;


    public void SELL()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, RayCastLength, mask);
        GameObject SoldObject = hit.collider.gameObject;

        Destroy(SoldObject);
        if (hit.collider != null)
        {
            if (SoldObject.name == "Image1(Clone)")
            {
                MoneyScript.Money += MoneyScript.Item1price;
                BuyScript.MoneyManagerUpdate();
            }

            if (SoldObject.name == "Image2(Clone)")
            {
                MoneyScript.Money += MoneyScript.Item2price;
                BuyScript.MoneyManagerUpdate();
            }

            if (SoldObject.name == "Image3(Clone)")
            {
                MoneyScript.Money += MoneyScript.Item3price;
                BuyScript.MoneyManagerUpdate();
            }

            if (SoldObject.name == "Image4(Clone)")
            {
                MoneyScript.Money += MoneyScript.Item4price;
                BuyScript.MoneyManagerUpdate();
            }
        }
    }
}
