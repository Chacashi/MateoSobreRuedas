using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetTime(string text);
    public void ChangueScene(string newScene)
    {
        Time.timeScale = 1f;   // REINICIAR EL TIEMPO
#if UNITY_WEBGL && !UNITY_EDITOR
                                    SetTime("");
#endif
        SceneManager.LoadScene(newScene);
    }



    public void Exit()
    {
        Application.Quit();
    }
}
