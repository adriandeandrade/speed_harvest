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
                product.Initialize();
            }
        }
    }
}
