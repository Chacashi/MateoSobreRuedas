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

    private float totalSeconds;
    private bool isRunning = false;

    void Start()
    {
     
        totalSeconds = startHours * 3600 + startMinutes * 60 + startSeconds;
        isRunning = true;
        UpdateTimerText(); 
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
            timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        else
            timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimerEnd()
    {

        Debug.Log("¡El tiempo se acabó!");
    }


    public void ResetTimer(int h, int m, int s)
    {
        startHours = h;
        startMinutes = m;
        startSeconds = s;
        totalSeconds = h * 3600 + m * 60 + s;
        isRunning = true;
        UpdateTimerText();
    }
}
