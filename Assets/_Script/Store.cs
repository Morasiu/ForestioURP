using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Store:MonoBehaviour
{
    public int cost;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if (cost > Seed.Value)
        {
             button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
    public void OnBuy()
    {
        Seed.Value -= cost;
    }
}
