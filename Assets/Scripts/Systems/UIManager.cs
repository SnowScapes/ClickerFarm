using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextUI ProgressText;
    [SerializeField] private TextUI GoldGainText;
    [SerializeField] private TMP_Text GoldText;
    
    private void Start()
    {
        GameManager.Instance.Crop.ClickEvent += ProgressText.ShowText;
        GameManager.Instance.Crop.GainMoney += GoldGainText.ShowText;
        GameManager.Instance.Crop.GainMoney += ChangeGoldText;
    }

    private void ChangeGoldText(float _)
    {
        GoldText.text = GameManager.Instance.stat.Money.ToString();
    }
}
