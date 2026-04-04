using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueToText : MonoBehaviour
{
    public Slider slider;
    public Text textValue;
    public TextMeshProUGUI textPro;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((float sliderValue)=> {
            Print(sliderValue.ToString());
        });

        //默认显示
        Print(slider.value.ToString());
    }

    private void Print(string content)
    {
        if (textValue != null)
        {
            textValue.text = content;
        }
        if (textPro != null)
        {
            textPro.text = content;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
