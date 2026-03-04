using UnityEngine;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    bool isPaused = false;
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Pause.performed += ctx => TogglePause();
    }
    private void OnDisable()
    {
        controls.Player.Pause.performed -= ctx => TogglePause();
        controls.Disable();
    }

    void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = false;
    }
    public void EndScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
