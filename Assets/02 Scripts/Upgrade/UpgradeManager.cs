using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    [SerializeField] private UI_Upgrade[] _uiUpgrades;
    public UI_Upgrade[] UIUpgrades => _uiUpgrades;

    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        foreach (var upgrade in _upgrades)
        {
            upgrade.Init();
        }
    }

    public void Start()
    {
        RefreshUI();
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = _upgrades[index];
        if (ScoreManager.Instance.Score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.Spend(upgrade.Cost);

        _upgrades[index].LevelUp();

        RefreshUI();
    }

    private void RefreshUI()
    {
        if (_uiUpgrades == null) return;

        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            if (uiUpgrade != null)
            {
                uiUpgrade.Refresh();
            }
        }
    }
}