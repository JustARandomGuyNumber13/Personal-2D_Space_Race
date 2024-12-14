using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountDown : MonoBehaviour
{
    [SerializeField] private float countDownDuration;
    [SerializeField] private Game_Handler gameHandler;
    [SerializeField] private  BG_Scroll[] bgScrollScript;
    [SerializeField] private P_PlayerHandler[] playerHandlers;
    [SerializeField] private O_Spawn[] p1_spawners;
    [SerializeField] private O_Spawn[] p2_spawners;
    [SerializeField] private TMP_Text[] countDownTexts;

    private float countDown;

    private void Awake()
    {
        countDown = countDownDuration;
        ToggleScripts(false);
    }
    private void Update()
    {
        foreach(TMP_Text a in countDownTexts)
            a.text = Mathf.CeilToInt(countDown) + "";
        CountDown();
    }

    private void CountDown()
    {
        if (countDown > 0)
            countDown -= Time.deltaTime;
        else
        {
            ToggleScripts(true);
            Destroy(this.gameObject);
        }
    }
    private void ToggleScripts(bool value)
    {
        gameHandler.enabled = value;
        foreach(BG_Scroll a in bgScrollScript) 
            a.enabled = value;
        foreach(P_PlayerHandler a in playerHandlers)
            a.enabled = value;
        foreach(O_Spawn a in p1_spawners)
            a.enabled = value;
        foreach(O_Spawn a in p2_spawners)
            a.enabled = value;
    }
}
