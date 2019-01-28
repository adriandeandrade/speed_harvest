using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Image timerSprite;

    [SerializeField] private RectTransform cuppingPos;
    [SerializeField] private RectTransform wrappingPos;
    [SerializeField] private RectTransform pricingPos;

    public void ChangePosition(Product product)
    {
        switch (product.processingState)
        {
            case Product.ProcessingState.CUPPING:
                transform.position = cuppingPos.position;
                break;
            case Product.ProcessingState.WRAPPING:
                transform.position = wrappingPos.position;
                break;
            case Product.ProcessingState.PRICING:
                transform.position = pricingPos.position;
                break;
        }
    }
}
