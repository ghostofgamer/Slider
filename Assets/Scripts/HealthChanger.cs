using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;

    private float _speed = 10f;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.CurrentHealth;
        ChangeColorHealthBar();
    }

    private void OnEnable()
    {
        _player.HealthChanger += StartIEnumerator;
    }

    private void OnDisable()
    {
        _player.HealthChanger -= StartIEnumerator;
    }

    private void StartIEnumerator(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSliderValue(value));
    }

    private IEnumerator ChangeSliderValue(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _speed * Time.deltaTime);
            ChangeColorHealthBar();
            yield return null;
        }
    }

    private void ChangeColorHealthBar()
    {
        var needTimeEvaluate = _slider.value / 100f;
        _slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(needTimeEvaluate);
    }
}
