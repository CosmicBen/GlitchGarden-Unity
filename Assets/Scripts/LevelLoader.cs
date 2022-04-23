using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float splashScreenDelay = 3.0f;
    private int currentSceneIndex = 0;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreen(splashScreenDelay));
        }
    }

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator LoadStartScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("OptionsScreen");
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
