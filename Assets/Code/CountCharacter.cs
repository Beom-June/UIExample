using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCharacter : MonoBehaviour
{
    // ĳ���� ������ ���� ���� UI Script
    public Text havingText;
    int characterCount;
    void Update()
    {
        characterCount = GameObject.FindGameObjectsWithTag("Character").Length;

        for (int i = 0; i < characterCount; i++)
        {
            havingText.text = string.Format($" {i+1} / 100 ");
        }
    }
}
