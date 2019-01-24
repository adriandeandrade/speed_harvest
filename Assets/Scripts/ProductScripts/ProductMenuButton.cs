using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductMenuButton : MonoBehaviour
{
    private TaskManager taskManager;
    private Product productInstance;
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { SelectProduct(); }); // Add a listener and execute the SelectProduct function when clicked.
    }

    private void Start()
    {
        taskManager = TaskManager.instance;
    }

    public void SetProduct(Product product)
    {
        productInstance = product; // Set the product instance for the button so that it contains the right data.
    }

    public void SelectProduct()
    {
        Debug.Log("Product " + productInstance.productData.productName + " has been selected.");

        if (taskManager.currentlySelectedProduct != productInstance)
        {
            taskManager.currentlySelectedProduct = null;
            taskManager.currentlySelectedProduct = productInstance;
            //Debug.Log("Selected product: " + taskManager.currentlySelectedProduct.productData.productName);
        }
    }
}
