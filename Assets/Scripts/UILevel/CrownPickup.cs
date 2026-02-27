using UnityEngine;

public class CrownPickup : MonoBehaviour
{
    public GameOverUI winUI;

    private void OnDisable()
    {
        if (winUI != null)
            winUI.ShowWinScreen();
    }
}
