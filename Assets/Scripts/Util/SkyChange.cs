using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChange : MonoBehaviour
{
    [SerializeField] private Renderer skyDome;
    private Vector2 nightSkyPreset = new Vector2(0.5f, 0);
    [SerializeField] private Light sunLight;
    [SerializeField] private Color dayLightColor;
    [SerializeField] private Color nightLightColor;

    public void ChangeLightToNight()
    {
        skyDome.material.mainTextureOffset = nightSkyPreset;
        sunLight.color = nightLightColor;
    }

    public void ChangeLightToDay()
    {
        skyDome.material.mainTextureOffset = Vector2.zero;
        sunLight.color = dayLightColor;
    }
}
