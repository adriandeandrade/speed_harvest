using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    #region Singleton
    public static TaskManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    #endregion

    public SaleManager saleManager;
    public TaskTimer taskTimer;

    public Product currentlySelectedProduct;
    [HideInInspector] public bool currentlyProcessing;

    [HideInInspector] public float processTimeLeft;
    [HideInInspector] public float processingTime;

    private void Start()
    {
        currentlyProcessing = false;
    }

    public void ProcessProduct(Product selectedProduct, int amountOfProcesses)
    {
        currentlySelectedProduct = selectedProduct;

        if (currentlyProcessing)
        {
            Debug.Log("Cannot process 2 products at the same time!");
            return;
        }

        if (selectedProduct != null && !currentlyProcessing)
        {
            currentlyProcessing = true;
            selectedProduct.processingState = Product.ProcessingState.CUPPING;
            StartCoroutine(ProcessingTask(selectedProduct, amountOfProcesses));
            Debug.Log("Currently being processed: " + selectedProduct.productData.productName);
        }
        else
        {
            Debug.Log("No product selected.");
        }
    }

    IEnumerator ProcessingTask(Product product, int amountOfProcesses)
    {
        switch (product.processingState)
        {
            case Product.ProcessingState.CUPPING:
                processTimeLeft = product.productData.cuppingTime * amountOfProcesses;
                break;
            case Product.ProcessingState.WRAPPING:
                processTimeLeft = product.productData.wrappingTime * amountOfProcesses;
                break;
            case Product.ProcessingState.PRICING:
                processTimeLeft = product.productData.pricingTime * amountOfProcesses;
                break;

            default:
                processTimeLeft = 3f;
                break;
        }

        processingTime = processTimeLeft;

        taskTimer.gameObject.SetActive(true);
        taskTimer.ChangePosition(product);

        while (processTimeLeft > 0f)
        {
            yield return new WaitForSeconds(1f);
            processTimeLeft--;
            taskTimer.timerSprite.fillAmount = processTimeLeft / processingTime;
            taskTimer.timerText.SetText(processTimeLeft.ToString());
        }

        

        if (product.processingState == Product.ProcessingState.PRICING)
        {
            StopCoroutine(ProcessingTask(product, amountOfProcesses));
            currentlyProcessing = false;
            taskTimer.gameObject.SetActive(false);
            Debug.Log("Finished processing product.");
            CalculatePrice(product);
        }
        else
        {
            product.NextState();
            taskTimer.ChangePosition(product);
            StartCoroutine(ProcessingTask(product, amountOfProcesses));
        }

        yield return null;
    }

    private void CalculatePrice(Product product)
    {
        float amountToPrice = Random.Range(7, 10);
        for (int i = 0; i < amountToPrice - 1; i++)
        {
            float packWeight = ChooseRandomPackWeight();
            float packPrice = packWeight * product.sellPrice;
            saleManager.AddSale(packPrice);
            Debug.Log("Pack Price: " + packPrice);
        }
    }

    private float ChooseRandomPackWeight()
    {
        return Random.Range(1.500f, 1.800f);
    }
}
