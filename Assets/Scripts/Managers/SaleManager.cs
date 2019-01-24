using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleManager : MonoBehaviour
{
    public float salesGoal;
    public float finalSales;

    public void AddSale(float saleAmount)
    {
        finalSales += saleAmount;
    }

    public bool SalesGoalAchieved()
    {
        if(finalSales >= salesGoal)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
