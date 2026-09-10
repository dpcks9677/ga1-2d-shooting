using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글턴 패턴
    // 1. 전역적으로 접근이 가능함
    // 2. 인스턴스가 하나임을 보장한다.
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;

    // 관리: 특정 데이터에 대한 무결성과 추가, 수정, 삭제 등과 관련된 로직을 말함

    private int _bestScore;
    private int _currentScore;

    // UI 책임 추가
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private void Awake()
    {
        // 중복 생성 방지 코드
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    // Getter
    public int GetScore()
    {
        return _currentScore;
    }

    // Setter
    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
    }

    private void Update()
    {
        RefreshText();
    }

    private void RefreshText()
    {
        _bestScoreText.text = $"Best Score: {_bestScore}";
        _currentScoreText.text = $"Score: {_currentScore}";
    }
}