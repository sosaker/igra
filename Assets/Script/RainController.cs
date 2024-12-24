using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem ps;
    private bool _isRain = false;
    public float lightChangeSpeed = 0.5f;
    private float _initialLightIntensity;

    private void Start()
    {
        if (dirLight != null)
        {
            _initialLightIntensity = dirLight.intensity;
        }

        ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (dirLight == null)
            return;

        float adjustedLightChangeSpeed = lightChangeSpeed * 10;

        if (_isRain && dirLight.intensity > 0f)
        {
            dirLight.intensity -= adjustedLightChangeSpeed * Time.deltaTime;
        }
        else if (!_isRain && dirLight.intensity < _initialLightIntensity)
        {
            dirLight.intensity += adjustedLightChangeSpeed * Time.deltaTime;
        }
    }

    private IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            if (_isRain)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }

            _isRain = !_isRain;
        }
    }
}
