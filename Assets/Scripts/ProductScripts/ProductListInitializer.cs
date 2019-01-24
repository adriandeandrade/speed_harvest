using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductListInitializer : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private ProductManager productManager;

    private void Start()
    {
        InitalizeButtons();
    }

    private void InitalizeButtons()
    {
        foreach (Product product in productManager.products)
        {
            GameObject newButton = Instantiate(buttonPrefab, transform);

            newButton.transform.GetChild(1).GetComponent<Image>().sprite = product.productData.productIcon;
            newButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = product.productData.productName;
            newButton.GetComponent<ProductMenuButton>().SetProduct(product);
        }
    }
}
