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

    public Product currentlySelectedProduct;
    //[SerializeField] private List<Task> tasks = new List<Task>();
    [HideInInspector] public bool currentlyProcessing;

    private enum ProcessState { CUPPING, WRAPPING, PRICING, IDLE };
    private ProcessState currentProcessState;

    private void Start()
    {
        currentlyProcessing = false;
        currentProcessState = ProcessState.IDLE;
    }

    public void ProcessProduct()
    {
        if(currentlyProcessing)
        {
            Debug.Log("Cannot process 2 products at the same time!");
            return;
        }

        if(currentlySelectedProduct != null && !currentlyProcessing)
        {
            currentProcessState = ProcessState.CUPPING;
            currentlyProcessing = true;
            StartCoroutine(Cup());
            Debug.Log("Currently being processed: " + currentlySelectedProduct.productData.productName);
        } else
        {
            Debug.Log("No product selected.");
        }
    }

    IEnumerator Cup()
    {
        float processingTime = currentlySelectedProduct.productData.cuppingTime;

        while(processingTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            processingTime--;
        }
        Debug.Log("Finished Cupping");
        StartCoroutine(Wrap());
        currentProcessState = ProcessState.WRAPPING;
        StopCoroutine(Cup());
    }

    IEnumerator Wrap()
    {
        float processingTime = currentlySelectedProduct.productData.wrappingTime;

        while (processingTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            processingTime--;
        }
        Debug.Log("Finished Wrapping");
        StartCoroutine(Price());
        currentProcessState = ProcessState.PRICING;
        StopCoroutine(Wrap());
    }

    IEnumerator Price()
    {
        float processingTime = currentlySelectedProduct.productData.pricingTime;

        while (processingTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            processingTime--;
        }
        Debug.Log("Finished Pricing");
        currentlyProcessing = false;
        currentProcessState = ProcessState.IDLE;
        StopCoroutine(Price());
    }

}
