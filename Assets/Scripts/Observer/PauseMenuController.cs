using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private List<IPausable> pausables = new List<IPausable>();

    public void AddPausable(IPausable pausable)
    {
        pausables.Add(pausable);
    }

    public void RemovePausable(IPausable pausable)
    {
        pausables.Remove(pausable);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;

                foreach (IPausable pausable in pausables)
                {
                    pausable.OnPause();
                }
            }
            else
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;

                foreach (IPausable pausable in pausables)
                {
                    pausable.OnResume();
                }
            }
        }
    }
}
