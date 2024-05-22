using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BuyMechanic : MonoBehaviour
{
    private int Offset = 3;
    public LayerMask Mask;

    private int LastPoint = -1;

    public MoneyManager MoneyScript;


    public Transform[] BackPackSlots;

    public Transform CloneSlot;

    public Vector3 size = new Vector3(1, 1, 0);

    public void BuyTest()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Offset, Mask);
        GameObject Item = hit.collider.gameObject;


        if (hit.collider != null)
        {
            if (Item.name == "Image1")
            {
                MoneyScript.Money -= MoneyScript.Item1price;
            }

            if (Item.name == "Image2")
            {
                MoneyScript.Money -= MoneyScript.Item2price;
            }

            if (Item.name == "Image3")
            {
                MoneyScript.Money -= MoneyScript.Item3price;
            }

            if (Item.name == "Image4")
            {
                MoneyScript.Money -= MoneyScript.Item4price;
            }





            int startIndex = LastPoint + 1;

            if (startIndex >= BackPackSlots.Length) //rechecks all the spaces all over after the last spot
            {
                startIndex = 0;
            }
            for (int i = startIndex; i < BackPackSlots.Length; i++)
            {
                Transform space = BackPackSlots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    Debug.Log("llllllllll");

                    GameObject ClonedObject = Instantiate(Item, space.position, Quaternion.identity, CloneSlot);
                    ClonedObject.transform.localScale = size;
                    ClonedObject.AddComponent<DragAndDrop>();
                    LastPoint = i;

                    MoneyManagerUpdate();
                    return;

                }
            }

            for (int i = 0; i < startIndex; i++)
            {
                Transform space = BackPackSlots[i];

                Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

                if (colliders.Length == 0)
                {
                    GameObject ClonedObject = Instantiate(Item, space.position, Quaternion.identity, CloneSlot);
                    ClonedObject.transform.localScale = size;
                    ClonedObject.AddComponent<DragAndDrop>();

                    LastPoint = i;
                }
                return;
            }


        }
    }


    public void MoneyManagerUpdate()
    {
        MoneyScript.MoneyText.text = "Money : $" + MoneyScript.Money;

    }

    private void Start()
    {
        MoneyManagerUpdate();
    }


}