using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public void Start()
    {
        GameManager.instance.observeWave += UpdateWave;
        UpdateWave(0);
    }

    public void UpdateWave(int wave)
    {
        waveText.text = $"Wave: {wave}";
    }
}
