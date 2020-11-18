﻿using UnityEngine;
using UnityEngine.UI;

public class SceneArrengement : MonoBehaviour
{
    public Text GameNameText, PlayGameText, PriceText, ExitText;
    public Buttons Buttons;
    public GameObject MainCube;
    public GameObject ShopListCubes;

    private SpawnCubes spawnCubes;
    private string keySkin = "Skin";
    private string keyRestart = "Restart";
    private string keyLanguage = "Language";

    public void StartGame()
    {
        SwtichTextsScene();

        AnimateStartGameUI();
    }

    private void Start()
    {
        spawnCubes = GetComponent<SpawnCubes>();

        SetLanguage();
        SetSkin();
        Restart();
    }

    private void Restart()
    {
        if (PlayerPrefs.GetString(keyRestart) == "true")
        {
            PlayerPrefs.SetString(keyRestart, "false");
            StartGame();
        }
    }

    private void SetSkin()
    {
        if (PlayerPrefs.HasKey(keySkin))
        {
            Material loadMaterial = ShopListCubes.transform.GetChild(PlayerPrefs.GetInt(keySkin)).GetComponent<MeshRenderer>().material;
            MainCube.GetComponent<MeshRenderer>().material = loadMaterial;
        }
    }

    private void SetLanguage()
    {
        if (PlayerPrefs.HasKey(keyLanguage))
        {
            Language.PrintAnyLanguage(PlayGameText,
               "TAP TO PLAY",
               "НАЖМИ ДЛЯ ИГРЫ");
            Language.PrintAnyLanguage(PriceText,
              "200 GOLD",
              "200 ЗОЛОТЫХ");
            Language.PrintAnyLanguage(ExitText,
                "Quit the game?",
                "Выйти из игры?");
        }
    }

    private void Update()
    {
        if (!MainCube.GetComponent<Animation>().isPlaying)
        {
            MainCube.AddComponent<Rigidbody>();
            SwitchScriptsScene();
        }
    }

    private void SwtichTextsScene()
    {
        GameNameText.text = "0";
        PlayGameText.gameObject.SetActive(false);
    }

    private void AnimateStartGameUI()
    {
        Buttons.GoAway();
        MainCube.GetComponent<Animation>().Play("StartGameCube");
    }

    private void SwitchScriptsScene()
    {
        spawnCubes.GetNewCube();

        GetComponentInChildren<JumpClickController>().enabled = true;
        Destroy(this);
    }
}