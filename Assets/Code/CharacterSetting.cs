using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetting : MonoBehaviour
{
    #region ĳ���� enum ��
    // ĳ���� �Ӽ�
    public enum C_Type
    {
        Tree,
        Chilly,
        Fire,
        Moon,
        Mystery,
        Sun
    };
    // ĳ���� ���
    public enum C_Grade
    {
        Normal,
        Rare,
        Epic,
        Legend,
        Myth
    };
    #endregion

    [Header("ĳ���� ���� ��")]
    public C_Type characterType;                      // ĳ���� �Ӽ� Ÿ��
    public C_Grade characterGrade = C_Grade.Normal;                    // ĳ���� ���
    public int C_Stemina = 0;                           // ĳ���� ���׹̳�
    public int C_Level = 0;                             // ĳ���� ����
    public int Grade;                                 // ĳ���� ���

    [Header("ĳ���� UI")]
    public Text Text_Level;                           // Level Text ��� ����
    public Text Text_Stemina;                         // Stemina Text ��� ����
    public List<GameObject> GradeStarSet;

    public List<CharacterSet> CharacterGradeSet = new List<CharacterSet>();                         // ��͵� ��� 

    public class CharacterSet
    {
        public int char_Grade;
    }

    void Start()
    {
        // ��ư Ŭ���� �̰��� ������ �ϸ� ��
        Character_Stemina();

        Character_Level();

        GradeStar();
    }
    // ��� �� ǥ��
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
    // ��� ����
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

    // ���׹̳� UI ���
    public void Character_Stemina()
    {
        Text_Stemina.text = string.Format($" {C_Stemina} / 100 ");
    }

    // Level UI ���
    public void Character_Level()
    {
        Text_Level.text = string.Format($"Lv. {C_Level}");
    }
}
