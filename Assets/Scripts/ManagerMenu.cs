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
        PanelOptions.SetActive(true);
        for(int i = 0; i < Botones.Length; i++)
        {
            Botones[i].SetActive(false);
        }
    }
    public void CreditsPanel()
    {
        PanelCreditos.SetActive(true);
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].SetActive(false);
        }
    }
    public void ClosePanels()
    {
        PanelOptions.SetActive(false);
        PanelCreditos.SetActive(false);
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].SetActive(true);
        }
    }   
}
