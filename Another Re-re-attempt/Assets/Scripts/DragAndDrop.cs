using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DragAndDrop : MonoBehaviour
{

    private int snapDistance = 2;
    public Vector3 offset;
    public bool isDragging = false;

    public Transform[] ChestSlots;
    public Transform[] BackPackSlots;

    public ScrollRect Scroller;

    public BuyMechanic BuyScript;

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            
            if (Scroller != null)
            {
                Scroller.enabled = false;
            }

        }

        if (isDragging == false)
        {
            if (Scroller !=null)
            {
                Scroller.enabled = true;
            }
        }
       






    }
    void OnMouseDown()
    {
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {

        isDragging = false;

        foreach (Transform spots in transform.parent.GetComponent<DragAndDrop>().BackPackSlots)
        {

            // Check if the object is close enough to the target spot to snap it into place
            float distance = Vector3.Distance(transform.position, spots.position);
            if (distance <= snapDistance)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(spots.position, snapDistance);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != gameObject)
                    {

                        // transform.position = OriginalPosition;
                        return;
                    }
                }
                transform.position = spots.position;
                break;
            }
        }



        //foreach (Transform spots in transform.parent.GetComponent<DragAndDrop>().ChestSlots)
        {

            // Check if the object is close enough to the target spot to snap it into place
            //float distance = Vector3.Distance(transform.position, spots.position);
            //if (distance <= snapDistance)
            //{
                //Collider2D[] colliders = Physics2D.OverlapCircleAll(spots.position, snapDistance);

                //foreach (Collider2D collider in colliders)
                //{
                    //if (collider.gameObject != gameObject)
                    //{

                        // transform.position = OriginalPosition;
                        //return;
                    //}
                //}
                //transform.position = spots.position;
                //break;
            //}
        }









    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


}









