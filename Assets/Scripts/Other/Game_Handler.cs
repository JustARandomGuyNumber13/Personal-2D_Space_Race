using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Handler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private P_Stat player1;
    [SerializeField] private P_Stat player2;
    [SerializeField] private UI_Handler ui1, ui2;

    [Header("Others")]
    [SerializeField] private float trackDistance;

    void Awake()
    {
        SetUpGameEnviroment();
    }

    void Update()
    {
        UpdateDistance();
        CheckPlayerWin();
    }
    private void CheckPlayerWin()
    {
        if (player1.CurrentDistance >= trackDistance || player2.CurrentDistance >= trackDistance)
        {
            if (player1.CurrentDistance > player2.CurrentDistance)
                SceneManager.LoadScene("2_Player_1_Win");
            else if (player1.CurrentDistance < player2.CurrentDistance)
                SceneManager.LoadScene("3_Player_2_Win");
            else
                SceneManager.LoadScene("4_Draw");
        }
    }
    private void UpdateDistance()
    {
        player1.CurrentDistance += Time.deltaTime;
        ui1.Public_SetDistance(player1.CurrentDistance);

        player2.CurrentDistance += Time.deltaTime;
        ui2.Public_SetDistance(player2.CurrentDistance);
    }
    private void SetUpGameEnviroment()
    {
        player1.TrackLength = trackDistance;
        ui1.Public_SetMaxDistance(trackDistance);
        player1.CurrentDistance = 0;

        player2.TrackLength = trackDistance;
        ui2.Public_SetMaxDistance(trackDistance);
        player2.CurrentDistance = 0;
    }
}
