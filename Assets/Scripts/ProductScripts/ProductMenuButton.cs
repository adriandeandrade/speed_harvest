using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProductMenuButton : MonoBehaviour, IPointerEnterHandler
{
    private TaskManager taskManager;
    private Tooltip tooltip;
    private Product productInstance;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { SelectProduct(); }); // Add a listener and execute the SelectProduct function when clicked.
    }

    private void Start()
    {
        taskManager = TaskManager.instance;
        tooltip = FindObjectOfType<Tooltip>();
    }

    public void SetProduct(Product product)
    {
        productInstance = product; // Set the product instance for the button so that it contains the right data.
    }

    public void SelectProduct()
    {
        //Debug.Log("Product " + productInstance.productData.productName + " has been selected.");

        if (taskManager.currentlySelectedProduct != productInstance)
        {
            taskManager.currentlySelectedProduct = null;
            taskManager.currentlySelectedProduct = productInstance;
            //Debug.Log("Selected product: " + taskManager.currentlySelectedProduct.productData.productName);
            EnableProductProcessMenu(taskManager.currentlySelectedProduct);
        }
    }

    private void EnableProductProcessMenu(Product product)
    {
        GameManager.instance.productProcessMenu.SetActive(true);
        GameManager.instance.productProcessMenu.GetComponent<ProductSelectionMenu>().UpdateProductProcessMenu(product);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.UpdateToolTip(productInstance);
    }
}
