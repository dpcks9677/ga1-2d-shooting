using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private int _index;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _scoreCostText;

    public void Start()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(OnClick);
        }

        Refresh();
    }

    public void OnClick()
    {
        // 버튼이 눌리면 매니저에게 레벨업 요청
        UpgradeManager.Instance.LevelUp(_index);
    }

    public void Refresh()
    {
        if (UpgradeManager.Instance == null || UpgradeManager.Instance.Upgrades == null) return;
        if (_index < 0 || _index >= UpgradeManager.Instance.Upgrades.Length) return;

        Upgrade upgrade = UpgradeManager.Instance.Upgrades[_index];

        if (_titleText != null) _titleText.text = $"{upgrade.Name} Lv.{upgrade.Level}";
        if (_valueText != null) _valueText.text = $"{upgrade.CurrentValue} -> {upgrade.NextValue}";
        if (_scoreCostText != null) _scoreCostText.text = $"{upgrade.Cost:N0}";
    }
}