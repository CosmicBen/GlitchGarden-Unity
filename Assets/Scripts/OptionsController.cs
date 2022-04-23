using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.8f;

    [SerializeField] private Slider difficultySlider = null;
    [SerializeField] private float defaultDifficulty = 0.0f;

    private MusicPlayer musicPlayer = null;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();

        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Update()
    {
        if (musicPlayer != null)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("Music player not found. Did you start from Splash Screen?");
        }
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
}
