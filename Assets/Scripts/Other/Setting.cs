using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private Button backButton;
    [SerializeField] private String settingMenuSceneName;
    public static Setting instance;

    private bool isSettingEnable;


    /* Monobehavior methods */////////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        SetUpSettingController();
    }
    private void Update()
    {
        ToggleSettingMenuByKey();
    }


    /* Toggle Setting handlers *//////////////////////////////////////////////////////////////////////////////////////
    private void ToggleSettingMenuByKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleSettingMenu();
    }
    public void ToggleSettingMenu()
    {
        if (isSettingEnable)
            DisableSettingMenu();
        else
            EnableSettingMenu();
    }
    private void EnableSettingMenu()
    {
        isSettingEnable = true;
        Time.timeScale = 0;
        SceneManager.LoadScene(settingMenuSceneName, LoadSceneMode.Additive);
    }
    private void DisableSettingMenu()
    {
        isSettingEnable = false;
        Time.timeScale = 1;

        if(SceneManager.GetSceneByName(settingMenuSceneName).isLoaded)  // Unload setting canvas
            SceneManager.UnloadSceneAsync(settingMenuSceneName);
    }


    /* Other handlers *///////////////////////////////////////////////////////////////////////////////////////////////
    private void SetUpSettingController()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            ReplayBgm();     //instance.ReplayBgm();
            Destroy(this);
        }
    }
    public void ReplayBgm() // Reset audio when back to main menu scene
    {
        bgmAudio.time = 0;
        bgmAudio.Play();
    }
}