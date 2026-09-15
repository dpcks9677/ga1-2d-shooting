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

    private const string UpgradeSaveDataKey = "UpgradeSaveData";

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
        Load();

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

        Save();
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

    private void Save()
    {
        // 데이터 저장은 유의미한 정보만 저장한다. -> 레벨만 저장한다
        UpgradeSaveData saveData = new UpgradeSaveData(_upgrades.Length);
        for (int i = 0; i < _upgrades.Length; i++)
        {
            saveData.Name[i] = _upgrades[i].Name;
            saveData.Level[i] = _upgrades[i].Level;
        }

        // json 포맷으로 문자열 변환

        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(UpgradeSaveDataKey, json);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(UpgradeSaveDataKey)) return;

        string json = PlayerPrefs.GetString(UpgradeSaveDataKey, string.Empty);
        UpgradeSaveData saveData = JsonUtility.FromJson<UpgradeSaveData>(json);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            Debug.Log($"{_upgrades[i].Name} 로드 완료");
            _upgrades[i].SetLevel(saveData.Level[i]);
        }
    }
}