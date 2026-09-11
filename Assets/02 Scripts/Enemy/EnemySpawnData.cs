using UnityEngine;

// 데이터 클래스: 순수 데이터만 보관하고 전달하는 기능

[System.Serializable]
public class EnemySpawnData
{
    public GameObject EnemyPrefab;
    public int Weight;
}