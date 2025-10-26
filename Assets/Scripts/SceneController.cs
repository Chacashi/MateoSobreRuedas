using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangueScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
