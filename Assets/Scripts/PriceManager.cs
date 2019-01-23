using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    [SerializeField] private ProductManager productManager;
    [SerializeField] private float profitPercentage;

    private void Start()
    {
        productManager = GetComponent<ProductManager>();
        GeneratePrices();
    }

    public void GeneratePrices()
    {
        if (productManager.products != null)
        {
            foreach (Product product in productManager.products)
            {
                int costPrice = Random.Range(product.minCostPrice, product.maxCostPrice);
                product.costPrice = costPrice;

                float sellPrice = GeneratePrice(costPrice, product.caseWeight);
                product.sellPrice = sellPrice;
                Debug.Log(product.productName + " cost price:" + product.costPrice + "/n sell price: " + product.sellPrice);
            }
        }
    }

    private float GeneratePrice(int costPrice, int weightInKg)
    {
        float priceBeforePercentage = costPrice / weightInKg;
        float finalPricePerKg = priceBeforePercentage / profitPercentage;

        return finalPricePerKg;
    }
}
