using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _onButton;
    [SerializeField] private GameObject _offButton;
    [SerializeField] private GameObject[] _canvases;

    public void OnOnSettingsButtonPressed()
    {
        foreach(GameObject canvase in _canvases)
            canvase.SetActive(false);
        _settings.SetActive(true);
        _offButton.SetActive(true);
        _onButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OnOffSettingsButtonPressed()
    {
        foreach(GameObject canvase in _canvases)
            canvase.SetActive(true);
        _onButton.SetActive(true);
        _offButton.SetActive(false);
        _settings.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
