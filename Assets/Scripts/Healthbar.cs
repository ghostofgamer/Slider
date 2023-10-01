using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
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
        GetColorHealth();
    }

    private void OnEnable()
    {
        _player.HealthChanged += GetCurrentHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= GetCurrentHealth;
    }

    private void GetCurrentHealth(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealth(value));
    }

    private IEnumerator ChangeHealth(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _speed * Time.deltaTime);
            GetColorHealth();
            yield return null;
        }
    }

    private void GetColorHealth()
    {
        var needTimeEvaluate = _slider.value / 100f;
        _slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(needTimeEvaluate);
    }
}
