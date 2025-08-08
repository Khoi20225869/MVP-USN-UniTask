using TMPro;
using UI;
using UnityEngine;
using UI.Object.Text;

public class MoneyText : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        ResetText();
        InitText();
    }
    private void OnDestroy()
    {
        TxtEventManager.Instance.OnMoneyChanged -= HandleTextChanged;
    }
    
    private void InitText()
    {
        TxtEventManager.Instance.OnMoneyChanged += HandleTextChanged;
    }
    
    private void ResetText()
    {
        var currentMoney = GarageManager.GetCurrentMoney();
        moneyText.SetText(currentMoney.ToString());
    }

    private void HandleTextChanged()
    {
        ResetText();
    }
}
