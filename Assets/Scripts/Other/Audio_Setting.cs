using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio_Setting : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider bgmSlider;

    /* Monobehavior methods *///////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        float a;
        mixer.GetFloat("bgm", out  a);
        bgmSlider.value = a;
    }


    /* Other handlers */////////////////////////////////////////////////////////////////////////////////////////
    public void SetBgmVolume()
    {
        mixer.SetFloat("bgm", bgmSlider.value);
    }
    public void BackButtonHandler()
    {
        Setting.instance.ToggleSettingMenu();
    }
}
