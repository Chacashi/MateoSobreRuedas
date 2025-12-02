using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Tiempo Inicial")]
    [SerializeField] private int startHours = 0;
    [SerializeField] private int startMinutes = 5;
    [SerializeField] private int startSeconds = 0;

    [Header("UI")]
    [SerializeField] private TMP_Text timerText;

    [Header("Referencias")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject panelDerrota;

    private float totalSeconds;
    private bool isRunning = false;

    public static event Action<int> OnTimeCero;
    [DllImport("__Internal")]
    private static extern void SetTime(string text);
    void Start()
    {
        ResetTimer(startHours, startMinutes, startSeconds);

        if (panelDerrota != null)
            panelDerrota.SetActive(false);
    }

    private void OnEnable()
    {
        OnTimeCero += StopTimer;
    }

    private void OnDisable()
    {
        OnTimeCero -= StopTimer;
    }

    void Update()
    {
        if (!isRunning) return;

        if (totalSeconds > 0)
        {
            totalSeconds -= Time.deltaTime;
            if (totalSeconds < 0) totalSeconds = 0;
            UpdateTimerText();
        }
        else
        {
            isRunning = false;
            OnTimerEnd();
        }
    }

    private void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(totalSeconds / 3600);
        int minutes = Mathf.FloorToInt((totalSeconds % 3600) / 60);
        int seconds = Mathf.FloorToInt(totalSeconds % 60);

        if (hours > 0)
        {
            string gaaa ="Tiempo: " + $"{hours:00}:{minutes:00}:{seconds:00}";
#if UNITY_WEBGL && !UNITY_EDITOR
                                    SetTime(gaaa);
#endif
        }

        else
        {
            string gaaa = "Tiempo: " + $"{minutes:00}:{seconds:00}";
#if UNITY_WEBGL && !UNITY_EDITOR
                                    SetTime(gaaa);
#endif

        }

    }

    private void OnTimerEnd()
    {
        Debug.Log("¡El tiempo se acabó!");
#if UNITY_WEBGL && !UNITY_EDITOR
                                    SetTime("");
#endif
        if (Player != null)
            Player.SetActive(false);

        if (panelDerrota != null)
            panelDerrota.SetActive(true);

        Time.timeScale = 0f;

        OnTimeCero?.Invoke(0);
    }

    public void ResetTimer(int h, int m, int s)
    {
        startHours = h;
        startMinutes = m;
        startSeconds = s;

        totalSeconds = h * 3600 + m * 60 + s;

        isRunning = true;

        UpdateTimerText();
        Time.timeScale = 1f; 
    }

    public void StopTimer(int time)
    {
        totalSeconds = time;
    }
}
