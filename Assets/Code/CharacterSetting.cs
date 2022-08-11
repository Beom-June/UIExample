using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetting : MonoBehaviour
{
    #region 캐릭터 enum 값
    // 캐릭터 속성
    public enum C_Type
    {
        Tree,
        Chilly,
        Fire,
        Moon,
        Mystery,
        Sun
    };
    // 캐릭터 등급
    public enum C_Grade
    {
        Normal,
        Rare,
        Epic,
        Legend,
        Myth
    };
    #endregion

    [Header("캐릭터 세팅 값")]
    public C_Type characterType;                      // 캐릭터 속성 타입
    public C_Grade characterGrade = C_Grade.Normal;                    // 캐릭터 등급
    public int C_Stemina = 0;                           // 캐릭터 스테미나
    public int C_Level = 0;                             // 캐릭터 레벨
    public int Grade;                                 // 캐릭터 등급

    [Header("캐릭터 UI")]
    public Text Text_Level;                           // Level Text 담는 변수
    public Text Text_Stemina;                         // Stemina Text 담는 변수
    public List<GameObject> GradeStarSet;

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

        GradeStar();
    }
    // 등급 별 표시
    public void GradeStar()
    {
        if(characterGrade == C_Grade.Normal)
        {
                GradeStarSet[0].SetActive(true);
        }
        else if(characterGrade == C_Grade.Rare)
        {
            for (int i = 0; i < 1; i++)
            {
                GradeStarSet[i].SetActive(true);
            }
        }
        else if(characterGrade == C_Grade.Epic)
        {
            for (int i = 0; i < 2; i++)
            {
                GradeStarSet[i].SetActive(true);
            }
        }
        else if(characterGrade == C_Grade.Legend)
        {
            for (int i = 0; i < 3; i++)
            {
                GradeStarSet[i].SetActive(true);
            }
        }
        else if(characterGrade == C_Grade.Myth)
        {
            for (int i = 0; i < 4; i++)
            {
                GradeStarSet[i].SetActive(true);
            }
        }
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
        Text_Stemina.text = string.Format($" {C_Stemina} / 100 ");
    }

    // Level UI 출력
    public void Character_Level()
    {
        Text_Level.text = string.Format($"Lv. {C_Level}");
    }
}
