using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float multiply = 1.0f;
    [SerializeField] private Car car;

    public const string HIGHSCORE_KEY = "HighScore";

    private float score;


    void Start()
    {
        score = 0.0f;
    }


    void Update()
    {
        if (car.GetIsCarRunning())
        {
            score += Time.deltaTime * multiply;

            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    private void OnDestroy()
    {
        int currentHiScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
        if (currentHiScore < score) 
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, Mathf.FloorToInt(score));
        }
    }
}
