using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 관리: 특정 데이터에 대한 무결성과 추가, 수정, 삭제 등과 관련된 로직을 말함

    private int _bestScore;
    private int _currentScore;

    // UI 책임 추가
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    // Getter
    public int GetScore()
    {
        return _currentScore;
    }

    // Setter
    public void AddScore(int score)
    {
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