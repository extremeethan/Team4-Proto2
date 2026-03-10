using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChange : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject rawImagePanel;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);

        if (rawImagePanel != null)
            rawImagePanel.SetActive(false);
    }

    void Update()
    {
        bool escapePressed = Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame;
        bool controllerBack = Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame;

        if ((escapePressed || controllerBack) && rawImagePanel.activeSelf)
        {
            rawImagePanel.SetActive(false);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    public void ShowImage()
    {
        rawImagePanel.SetActive(true);
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