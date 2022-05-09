using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _healthSliderSpeed;
    [SerializeField] private Slider _sliderGreen;
    [SerializeField] private Slider _sliderRed;
    [SerializeField] private Slider _sliderBlooe;
    [SerializeField] private float _waitTime;

    public float inHealth;

    [HideInInspector] private float passedHealth;
    [HideInInspector] private float time;
    
    public void SetMaxHealth(float health)
    {
        _sliderGreen.maxValue = health;
        _sliderGreen.value = health;
        _sliderRed.maxValue = health;
        _sliderRed.value = health;
        _sliderBlooe.maxValue = health;
        _sliderBlooe.value = health;
        passedHealth = health;
    }
    private void Update()
    {
        SetHealth(inHealth);
    }
    public void SetHealth(float health)
    {
        if(passedHealth > health)
        {
            _sliderGreen.value = health;
            _sliderBlooe.value = health;
            if(time >= _waitTime)
            {
                _sliderRed.value -= Time.fixedDeltaTime * _healthSliderSpeed;
                passedHealth -= Time.fixedDeltaTime * _healthSliderSpeed;  
            }else
            {
                time += Time.fixedDeltaTime;
            }              
        }
        if(passedHealth < health)
        {
            _sliderBlooe.value = health;
            if(time >= _waitTime)
            {
                _sliderRed.value += Time.fixedDeltaTime * _healthSliderSpeed;
                passedHealth += Time.fixedDeltaTime * _healthSliderSpeed;
                _sliderGreen.value += Time.fixedDeltaTime * _healthSliderSpeed;
            }else
            {
                time += Time.fixedDeltaTime;
            }                   
        }
        if(passedHealth == health)
        {
            time = 0f;
        } 
    }
}