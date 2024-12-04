using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class StatUIManager : MonoBehaviour
{

    public static StatUIManager Instance { get; private set; }

    [Header("UI References")]
    public Slider hungerSlider;
    public Slider suitDurabilitySlider;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI durabilityText;

    private SurvivalStats SurvivalStats;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SurvivalStats = FindObjectOfType<SurvivalStats>();
        hungerSlider.maxValue = SurvivalStats.maxHunger;
        suitDurabilitySlider.maxValue = SurvivalStats.maxSuitDurability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateStatUI()
    {
        hungerSlider.value = SurvivalStats.currentHunger;
        suitDurabilitySlider.value = SurvivalStats.currentSuitDurability;

        hungerText.text = $"허기 : {SurvivalStats.GetHungerPercentage():F0}%";
        durabilityText.text = $"우주복 : {SurvivalStats.GetSuitDurabikityPercentage():F0}%";

        hungerSlider.fillRect.GetComponent<Image>().color =
            SurvivalStats.currentHunger <SurvivalStats.maxHunger * 0.3f ? Color.red : Color.green;
        suitDurabilitySlider.fillRect.GetComponent<Image>().color =
            SurvivalStats.currentSuitDurability < SurvivalStats.maxSuitDurability * 0.3f ? Color.red : Color.blue;
    }
}
