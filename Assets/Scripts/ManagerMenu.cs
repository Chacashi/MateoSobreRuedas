using UnityEngine;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour
{
    [SerializeField] private GameObject PanelOptions;
    [SerializeField] private GameObject PanelCreditos;
    [SerializeField] private GameObject[] Botones;
    void Start()
    {
        PanelOptions.SetActive(false);
        PanelCreditos.SetActive(false);

    }
    public void OptionsPanel()
    {
        if (!PanelOptions.activeSelf)
        {
            Time.timeScale = 0.0f;
            PanelOptions.SetActive(true);
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].SetActive(false);
            }
        }
        else
        {
            Time.timeScale = 1.0f;
            PanelOptions.SetActive(false);
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].SetActive(true);
            }
        }
        
      
    }
    public void CreditsPanel()
    {
        if (!PanelCreditos.activeSelf)
        {
            Time.timeScale = 0.0f;
            PanelCreditos.SetActive(true);
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].SetActive(false);
            }
        }
        else
        {
            Time.timeScale = 1.0f;
            PanelCreditos.SetActive(false);
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].SetActive(true);
            }
        }
        
    }

}
