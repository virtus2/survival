using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyButton : MonoBehaviour
{
    public Item item;
    public Image image;
    public Text nameText;
    public Text descText;
    public void SetUI(Item i)
    {
        item = i;
        image.sprite = item.itemSprite;
        nameText.text = LeanLocalization.GetTranslationText(item.itemName);
        descText.text = LeanLocalization.GetTranslationText(item.itemDescription);
    }
}
