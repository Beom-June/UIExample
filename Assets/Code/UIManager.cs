using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> CharacterCard = new List<GameObject>();                                         // ĳ���� ī�� 
    public List<GameObject> CharacterCard_Stemina;// = new List<GameObject>();                              // ĳ���� ���׹̳� UI

    public List<CharacterSet> CharacterGradeSet = new List<CharacterSet>();                         // ��͵� ��� 

    bool SteminaBool = false;
    public class CharacterSet
    {
        public int char_Grade;
    }

    // ���׹̳� ǥ��
    public void OnClickCheckStemina()
    {
        //CharacterCard_Stemina[currentActiveIndex].SetActive(false);

        //currentActiveIndex++;

        //if (currentActiveIndex >= CharacterCard_Stemina.Count)
        //{
        //    currentActiveIndex = 0;
        //}

        // ���� ���׹̳��� ���� ������
        if (SteminaBool == false)
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(true);
            }
            SteminaBool = true;
        }
        else
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(false);
            }
            SteminaBool = false;
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

}
