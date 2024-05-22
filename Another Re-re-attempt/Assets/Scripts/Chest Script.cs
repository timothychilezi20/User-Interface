using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    private int Offset = 2;
    public LayerMask Mask;

    public Transform[] ChestSlots;
    private int LastPoint = -1;


    // Start is called before the first frame update
    public void ChestMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Offset, Mask);
        GameObject Item = hit.collider.gameObject;

        int startIndex = LastPoint + 1;

        if (startIndex >= ChestSlots.Length) //rechecks all the spaces all over after the last spot
        {
            startIndex = 0;
        }
        for (int i = startIndex; i < ChestSlots.Length; i++)
        {
            Transform space = ChestSlots[i];

            Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

            if (colliders.Length == 0)
            {
                Debug.Log("llllllllll");

                Item.transform.position = space.position;
                Item.transform.localScale = new Vector3(1, 1, 0);
                Item.transform.SetParent(space);


                LastPoint = i;

                return;

            }
        }

        for (int i = 0; i < startIndex; i++)
        {
            Transform space = ChestSlots[i];

            Collider2D[] colliders = Physics2D.OverlapPointAll(space.position);

            if (colliders.Length == 0)
            {

                Item.transform.position = space.position;


                LastPoint = i;
            }
            return;
        }


    }

    public void Upgrade()
    {
        foreach (Transform slot in ChestSlots)
        {
            Collider2D collider = slot.GetComponent<Collider2D>();
            if(collider != null)
            {
                collider.enabled = false;
            }
        }
    }
}



