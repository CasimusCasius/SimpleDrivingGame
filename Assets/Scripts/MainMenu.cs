using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hiScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDurationInMinutes;
    [SerializeField] private AndroidNotificationHandler notificationHandler;
    [SerializeField] private IOSNotificationHandler iOSNotificationHandler;

    private int energy;

    private const string ENERGY_KEY = "Energy";
    private const string ENERGY_READY_KEY = "EnergyReady";

    private void Start()
    {
        hiScoreText.text = "High Score: " + PlayerPrefs.GetInt(ScoreSystem.HIGHSCORE_KEY, 0);

    }

    private void CheckEnergy()
    {
        energy = PlayerPrefs.GetInt(ENERGY_KEY, maxEnergy);

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(ENERGY_READY_KEY, string.Empty);
            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(ENERGY_KEY, energy);
#if UNITY_ANDROID
                notificationHandler.ScheduleNotification(energyReady);
#elif UNITY_IOS
                iOSNotificationHandler.ScheduleNotification(energyRechargeDurationInMinutes);
#endif

            }
        }
        energyText.text = $"Play ({energy})";
    }

    private void Update()
    {
        CheckEnergy();
    }

    public void Play()
    {
        if (energy > 0)
        {
            energy--;
            PlayerPrefs.SetInt(ENERGY_KEY, energy);
            if (energy == 0)
            {
                DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDurationInMinutes);

                string energyReadyString = energyReady.ToString();
                PlayerPrefs.SetString(ENERGY_READY_KEY, energyReadyString);
            }

            SceneManager.LoadScene("Game");
        }
    }
}
