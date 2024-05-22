
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private RectTransform rectTransform;
    public float xChestPosition = -1475f;
    public float yChestPosition = 70f;
    public float xShopPosition = -440f;
    public float yShopPosition = 70f;

    public GameObject Panel;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MoveToChest()
    {

        Panel.transform.position = new Vector3(xChestPosition, yChestPosition, 0);

    }

    public void MoveToShop()
    {

        Panel.transform.position = new Vector3(xShopPosition, yShopPosition, 0);

    }
}  

