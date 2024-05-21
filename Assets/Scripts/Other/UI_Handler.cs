using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] private Slider distanceTrack;

    public void Public_SetMaxDistance(float value)
    { 
        distanceTrack.maxValue = value;
    }
    public void Public_SetDistance(float value)
    { 
        distanceTrack.value = value;
    }
}
