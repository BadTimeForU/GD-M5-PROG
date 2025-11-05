using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text messageField;
    [SerializeField] Image itemImageHolder;
    [SerializeField] Slider shieldSlider;
    [SerializeField] Slider healthSlider;

    Coroutine messageRoutine;

    public void Bind(ShipHealth health, ShipShield shield, ShipInventory inventory)
    {
        health.OnHealthChanged += UpdateHealth;
        shield.OnEnergyChanged += UpdateShield;
        inventory.OnItemUsed += ShowMessage;
        inventory.OnItemChanged += UpdateItemIcon;
    }

    void UpdateHealth(int value)
    {
        if (healthSlider) healthSlider.value = value;
    }

    void UpdateShield(float value)
    {
        if (shieldSlider) shieldSlider.value = value;
    }

    void UpdateItemIcon(Color c)
    {
        if (itemImageHolder)
        {
            itemImageHolder.color = c;
            itemImageHolder.enabled = true;
        }
    }

    void ShowMessage(string msg)
    {
        if (messageField == null) return;
        if (messageRoutine != null) StopCoroutine(messageRoutine);
        messageRoutine = StartCoroutine(MessageRoutine(msg));
    }

    System.Collections.IEnumerator MessageRoutine(string msg)
    {
        messageField.enabled = true;
        messageField.text = msg;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
        messageRoutine = null;
    }
}