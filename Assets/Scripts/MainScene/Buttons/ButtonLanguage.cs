﻿using UnityEngine;
using UnityEngine.UI;

public class ButtonLanguage : MonoBehaviour
{
    public Sprite English, Russian;
    public Text PlayGameText, Record, PriceText, ExitText;

    private Image image;
    private string language;
    private string keyLanguage = "Language";

    public void GetLanguage()
    {
        if (language == "English")
        {
            image.sprite = Russian;
            language = "Russian";
            PlayerPrefs.SetString(keyLanguage, "Russian");
        }
        else if (language == "Russian")
        {
            image.sprite = English;
            language = "English";
            PlayerPrefs.SetString(keyLanguage, "English");
        }

        ChangeLangueageOnScene();
    }

    /// <summary>
    /// For correct entry into the GetLanguage() function, you need to invert the language variable;
    /// </summary>
    private void SetLanguage()
    {
        if (PlayerPrefs.HasKey(keyLanguage))
        {
            language = PlayerPrefs.GetString(keyLanguage) == "English" ? "Russian" : "English";
        }
        else
        {
            language = "Russian"; // to invert the language
        }

        GetLanguage();
    }

    private void ChangeLangueageOnScene()
    {
        Language.PrintAnyLanguage(PlayGameText,
            "TAP TO PLAY",
            "НАЖМИ ДЛЯ ИГРЫ");
        Language.PrintAnyLanguage(Record,
           "TOP: " + PlayerPrefs.GetInt("Record").ToString(),
           "Рекорд: " + PlayerPrefs.GetInt("Record").ToString());
        Language.PrintAnyLanguage(ExitText,
            "Quit the game?",
            "Выйти из игры?");
    }

    private void Start()
    {
        image = GetComponent<Image>();
        SetLanguage();
    }
}