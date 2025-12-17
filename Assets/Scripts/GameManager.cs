using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    private float _prevTime;
    private TextMeshProUGUI  _scoreText;

    private void Start()
    {
        _prevTime = Time.time;
        _scoreText = GameObject.Find("Canvas/Score").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Time.time -  _prevTime > 10f)
        {
            _prevTime = Time.time;
            IncreaseScore(10);
        }
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        
        _scoreText.text =  "Score: " + _score;
    }
}
