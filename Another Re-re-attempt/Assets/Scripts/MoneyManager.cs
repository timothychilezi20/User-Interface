using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int Money = 100;
    public TextMeshProUGUI MoneyText;

    public int Item1price, Item2price, Item3price, Item4price;

    private GameObject Button1,Button2,Button3,Button4;

    private void Start()
    {
        Button1 = GameObject.FindGameObjectWithTag("Button1");
        Button2 = GameObject.FindGameObjectWithTag("Button2");
        Button3 = GameObject.FindGameObjectWithTag("Button3");
        Button4 = GameObject.FindGameObjectWithTag("Button4");

    }

    private void Update()
    {
        if (Money < Item1price)
        {
            Button1.SetActive(false);
        }
        else if (Money >= Item1price)
        {
            Button1.SetActive(true);
        }

        if (Money < Item2price)
        {
            Button2.SetActive(false);
        }
        else if (Money >= Item2price)
        {
            Button2.SetActive(true);
        }

        if (Money < Item3price)
        {
            Button3.SetActive(false);
        }
        else if (Money >= Item3price)
        {
            Button3.SetActive(true);
        }

        if (Money < Item4price)
        {
            Button4.SetActive(false);
        }
        else if (Money >= Item4price)
        {
            Button4.SetActive(true);
        }
    }

}
