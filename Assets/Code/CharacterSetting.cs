using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetting : MonoBehaviour
{
    // ĳ���� �Ӽ� Ÿ��
    public enum Type
    {
        Fire,               // ��
        Forest,             // ��
        Water,              // ��
        Sod,                // ��
        Light,              // ��
        Dark                // ���
    };

    [Header("ĳ���� ���� ��")]
    public Type characterType;                      // ĳ���� �Ӽ� Ÿ�� ����
    public int Stemina = 0;                         // ĳ���� ���׹̳�
    public int Level = 0;                           // ĳ���� ����
    public int Grade;                            // ĳ���� ���

    [Header("ĳ���� UI")]
    public Text Text_Level;                        // Level Text ��� ����
    public Text Text_Stemina;                        // Stemina Text ��� ����

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
        Text_Stemina.text = string.Format($" {Stemina} / 100 ");
    }

    // Level UI ���
    public void Character_Level()
    {
        Text_Level.text = string.Format($"Lv. {Level}");
    }
}
