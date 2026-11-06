using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{

    public TMP_Text slotText;

    public void FillSlot(SOItem _item, int _amount)
    {
        slotText.text = $"{_item.itemName} - {_amount}/{_item.maxStackSize}";
    }
}
