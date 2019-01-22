using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMenuButton : MonoBehaviour
{
    private TaskManager taskManager;

    private void Start()
    {
        taskManager = TaskManager.instance;
    }

    public void SelectProduct(Product product)
    {
        Debug.Log("Product " + product.productName + " has been selected.");

        if(taskManager.currentlySelectedProduct != product)
        {
            taskManager.currentlySelectedProduct = null;
            taskManager.currentlySelectedProduct = product;
        }
    }
}
