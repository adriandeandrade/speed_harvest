using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI prepTimeText;    
    [SerializeField] private TextMeshProUGUI wrapTimeText;    
    [SerializeField] private TextMeshProUGUI priceTimeText;    
    [SerializeField] private TextMeshProUGUI pricePerCaseText;    
    [SerializeField] private TextMeshProUGUI pricePerKGText;
    
    public void UpdateToolTip(Product product)
    {
        prepTimeText.SetText("Prep Time: " + product.productData.cuppingTime + " seconds");
        wrapTimeText.SetText("Wrap Time: " + product.productData.wrappingTime + " seconds");
        priceTimeText.SetText("Price Time: " + product.productData.pricingTime + " seconds");
        pricePerCaseText.SetText("Price Per Case: " + product.costPrice + " $");
        pricePerKGText.SetText("Price Per KG: " + product.sellPrice.ToString("#.00") + " $");
    }
}
