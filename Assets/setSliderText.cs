using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class setSliderText : MonoBehaviour
{

    // Start is called before the first frame update
    public void setText(Slider slider)
    {
        TextMeshProUGUI txt = gameObject.GetComponent<TextMeshProUGUI>();
        float val = slider.value;
        PlayerPrefs.SetInt("skipTime", (int)val);
        txt.SetText(val.ToString("R"));
    }
}
