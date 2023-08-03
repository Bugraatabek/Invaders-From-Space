using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    
    private void Start() 
    {
        Purse.instance.onCollectCoin += UpdateUI;
    }

    public void UpdateUI()
    {
        coinText.text = Purse.instance.Coins.ToString();
    }    
}