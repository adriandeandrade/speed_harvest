using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaleManager : MonoBehaviour
{
    public float salesGoal;
    public float currentSales;

    [SerializeField] private TextMeshProUGUI salesGoalText;
    [SerializeField] private TextMeshProUGUI currentSalesText;

    private void Start()
    {
        salesGoal = 10000;
    }

    public void GenerateSalesGoal()
    {

    }

    public void AddSale(float saleAmount)
    {
        currentSales += saleAmount;
        salesGoalText.SetText("Current Sales: " + currentSales.ToString("#.00") + "$");
    }

    public bool SalesGoalAchieved()
    {
        if(currentSales >= salesGoal)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
