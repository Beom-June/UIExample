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
    public int Grade;                            // 캐릭터 등급

    [Header("캐릭터 UI")]
    public Text Text_Level;                        // Level Text 담는 변수
    public Text Text_Stemina;                        // Stemina Text 담는 변수

    public List<CharacterSet> CharacterGradeSet = new List<CharacterSet>();                         // 희귀도 등급 

    public class CharacterSet
    {
        public int char_Grade;
    }

    void Start()
    {
        // 버튼 클릭시 이것이 나오게 하면 됨
        Character_Stemina();

        Character_Level();
    }

    // 등급 정렬
    public void OnClickSetGrade()
    {
        CharacterGradeSet.Sort(delegate (CharacterSet A, CharacterSet B)
        {
            if (A.char_Grade < B.char_Grade)
                return 1;
            else if (A.char_Grade > B.char_Grade)
                return -1;
            return 0;
        });
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
