using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public ProductObject productData;
    
    public float caseWeight;
    private float costPrice;
    private float sellPrice;
    public float minCostPrice;
    public float maxCostPrice;

    public void Initialize()
    {
        float costPrice = Mathf.Round(Random.Range(minCostPrice, maxCostPrice));
        this.costPrice = costPrice;

        float sellPrice = GeneratePrice(costPrice, caseWeight);
        this.sellPrice = sellPrice;
        //Debug.Log(productData.productName + " Cost price:" + costPrice + "\n Sell price: " + sellPrice);
    }

    private float GeneratePrice(float costPrice, float weightInKg)
    {
        float priceBeforePercentage = costPrice / weightInKg;
        float finalPricePerKg = priceBeforePercentage / 0.70f;

        return finalPricePerKg;
    }
}
