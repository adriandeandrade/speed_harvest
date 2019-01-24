using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product Object", menuName = "Prodcuts/New Product")]
public class ProductObject : ScriptableObject
{
    public Sprite productIcon;
    public float cuppingTime;
    public float wrappingTime;
    public float pricingTime;

    public string productName;
}
