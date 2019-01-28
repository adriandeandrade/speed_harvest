using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public ProductObject productData;
    
    public float caseWeight;
    [HideInInspector] public float costPrice;
    [HideInInspector] public float sellPrice;
    public float minCostPrice;
    public float maxCostPrice;

    [HideInInspector] public enum ProcessingState { CUPPING, WRAPPING, PRICING, IDLE }
    [HideInInspector] public ProcessingState processingState;

    public void Initialize()
    {
        processingState = ProcessingState.IDLE;
        float costPrice = Mathf.Round(Random.Range(minCostPrice, maxCostPrice));
        this.costPrice = costPrice;

        float sellPrice = GeneratePrice(costPrice, caseWeight);
        this.sellPrice = sellPrice;
        //Debug.Log(productData.productName + " Cost price:" + costPrice + "\n Sell price: " + sellPrice);
    }

    private float GeneratePrice(float costPrice, float weightInPounds)
    {
        float poundsToKG = weightInPounds / 2.2f;
        float priceBeforePercentage = costPrice / poundsToKG;
        float finalPricePerKg = priceBeforePercentage / 0.70f;

        return finalPricePerKg;
    }

    public void NextState()
    {
        switch(processingState)
        {
            case ProcessingState.CUPPING:
                processingState = ProcessingState.WRAPPING;
                break;
            case ProcessingState.WRAPPING:
                processingState = ProcessingState.PRICING;
                break;
            case ProcessingState.PRICING:
                return;
        }

        Debug.Log("Processing state:" + processingState);
    }
}
