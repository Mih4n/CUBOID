using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class DeathScript : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private GameObject[] _canvases;

    [HideInInspector] private string _rewardedUnitId = "ca-app-pub-3940256099942544/5224354917";
    [HideInInspector] private RewardedAd _rewardedAd;

    void Update() 
    {
        if(_player.Health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _deathScreen.SetActive(true);
        Time.timeScale = 0f;
        foreach(GameObject canvase in _canvases)
            canvase.SetActive(false);
    }

    private void Rebirth()
    {
        _player.RestoreHealth(100);
        Time.timeScale = 1f;
        _deathScreen.SetActive(false);
        foreach(GameObject canvase in _canvases)
            canvase.SetActive(true);
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        _rewardedAd = new RewardedAd(_rewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(adRequest);
        _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        _player.RestoreHealth(100);
        Time.timeScale = 1f;
        _deathScreen.SetActive(false);
        foreach(GameObject canvase in _canvases)
            canvase.SetActive(true);
    }

    public void ShowAd()
    {
        if (_rewardedAd.IsLoaded())
            _rewardedAd.Show();
    }

}
