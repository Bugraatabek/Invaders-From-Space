using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour 
{
    EquipLocation equipLocation;
    [SerializeField] Image image;

    public void SetupUI(Sprite itemSprite, EquipLocation equipLocation)
    {
        image.sprite = itemSprite;
        this.equipLocation = equipLocation;
    }    
}