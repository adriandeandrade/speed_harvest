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
    [SerializeField] private List<Task> tasks = new List<Task>();
    private bool currentlyProcessing;

    private enum ProcessState { CUPPING, WRAPPING, PRICING, IDLE };
    private ProcessState currentProcessState;

    private void Start()
    {
        currentlyProcessing = false;
        currentProcessState = ProcessState.IDLE;
    }

    public void ProcessProduct()
    {
        if(currentlySelectedProduct != null && !currentlyProcessing)
        {
            currentProcessState = ProcessState.CUPPING;
            currentlyProcessing = true;
            StartCoroutine(Cup());
            Debug.Log("Currently being processed: " + currentlySelectedProduct.productName);
        } else
        {
            Debug.Log("No product selected.");
        }
    }

    IEnumerator Cup()
    {
        float processingTime = tasks[0].processingTime;

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
        float processingTime = tasks[1].processingTime;

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
        float processingTime = tasks[2].processingTime;

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
