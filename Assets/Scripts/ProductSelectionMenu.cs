using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductSelectionMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI productName;
    [SerializeField] private TextMeshProUGUI amountToProcess;

    [SerializeField] private Image productIcon;

    private int currentAmount = 1;

    private int maxAmount = 10;
    private int minAmount = 1;

    private void Start()
    {
        currentAmount = 1;
        amountToProcess.SetText("Amount to process: " + currentAmount.ToString());
    }

    public void UpdateProductProcessMenu(Product product)
    {
        productName.SetText(product.productData.productName);
        productIcon.sprite = product.productData.productIcon;
    }

    public void Process()
    {
        TaskManager.instance.ProcessProduct();
        gameObject.SetActive(false);
    }

    public void ExitMenu()
    {
        gameObject.SetActive(false);
    }

    public void Add()
    {
        if(currentAmount < maxAmount)
        {
            currentAmount++;
            UpdateAmountText();
        } else
        {
            // Play error sound

            return;
        }
    }

    public void Subtract()
    {
        if(currentAmount > minAmount)
        {
            currentAmount--;
            UpdateAmountText();
        } else
        {
            // Play error sound

            return;
        }
    }

    private void UpdateAmountText()
    {
        amountToProcess.SetText("Amount to process: " + currentAmount.ToString());
    }
}
