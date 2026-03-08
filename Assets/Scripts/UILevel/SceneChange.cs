using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject firstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EndScene()
    {
        Debug.Log("Quit pressed");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
