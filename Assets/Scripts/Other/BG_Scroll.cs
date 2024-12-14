using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_Scroll : MonoBehaviour
{
    private SpriteRenderer img;
    private Vector2 scrollDir;

    private void Start()
    {
        img = GetComponent<SpriteRenderer>();
        scrollDir = new Vector2(0, 0.2f);
    }

    void Update()
    {
        img.material.mainTextureOffset += scrollDir * Time.deltaTime;
    }
}

