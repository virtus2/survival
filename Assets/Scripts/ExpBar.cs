using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public float exp;
    public Slider slider;
    // Start is called before the first frame update
    private void Start()
    {
        slider.value = 0;
    }
    public void SetExp(float exp)
    {
        slider.value = exp;
    }
}
