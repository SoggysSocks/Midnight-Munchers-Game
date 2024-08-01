using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToiletUI : MonoBehaviour

{
    public Slider peeBarSlider;
    public TextMeshProUGUI peeBarValueText;

    public ToiletScript toiletScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        peeBarValueText.text = toiletScript.toiletScore.ToString() + "/" + toiletScript.scoreMax.ToString();

        peeBarSlider.value = toiletScript.toiletScore;
        peeBarSlider.maxValue = toiletScript.scoreMax;
    }
}
