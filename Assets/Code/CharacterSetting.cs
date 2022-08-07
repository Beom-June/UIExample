using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetting : MonoBehaviour
{
    // 캐릭터 속성 타입
    public enum Type
    { 
        Fire,               // 불
        Forest,             // 숲
        Water,              // 물
        Sod,                // 땅
        Light,              // 빛
        Dark                // 어둠
    };

    [Header("캐릭터 세팅 값")]
    public Type characterType;                      // 캐릭터 속성 타입 설정
    public int Stemina = 0;                         // 캐릭터 스테미나
    public int Level = 0;                           // 캐릭터 레벨
    public string Grade;                            // 캐릭터 등급

    [Header("캐릭터 UI")]
    public Text Text_Level;                        // Level Text 담는 변수
    public Text Text_Stemina;                        // Stemina Text 담는 변수

    void Start()
    {
        // 버튼 클릭시 이것이 나오게 하면 됨
        Character_Stemina();

        Character_Level();
    }

    void Update()
    {
        
    }

    // 스테미나 UI 출력
    public void Character_Stemina()
    {
        Text_Stemina.text = string.Format($" {Stemina} / 100 ");
    }

    // Level UI 출력
    public void Character_Level()
    {
        Text_Level.text = string.Format($"Lv. {Level}");
    }
}
