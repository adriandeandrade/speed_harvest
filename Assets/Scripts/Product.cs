using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Products/New Product")]
public class Product : ScriptableObject
{
    public string productName;
    public float productPrice;
    public Sprite productSprite;
}
