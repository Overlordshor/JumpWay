﻿using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject PlayButton, SocialGroupBar, AdvertisingButton;

    private void OnEnable()
    {
        ToggleAllUI();
    }

    private void OnDisable()
    {
        ToggleAllUI();
    }

    private void ToggleUI(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void ToggleAllUI()
    {
        ToggleUI(PlayButton);
        ToggleUI(SocialGroupBar);
    }
}