using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SupplyPanel : MonoBehaviour
{
    public Image image;
    public Text text;
    public SupplyButton buttonTop;
    public SupplyButton buttonMiddle;
    public SupplyButton buttonBottom;

    public void SetButtonUI(List<Item> items)
    {
        buttonTop.SetUI(items[0]);
        buttonMiddle.SetUI(items[1]);
        buttonBottom.SetUI(items[2]);
    }

    public void OnSupplyButtonClicked(SupplyButton button)
    {
        GameManager.Instance.OnSupplyChoose(button.item);
        UIController.Instance.OnSupplyButtonClicked();
    }
}
