using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> CharacterCard = new List<GameObject>();                                         // ĳ���� ī�� 
    public List<GameObject> CharacterCard_Stemina;// = new List<GameObject>();                              // ĳ���� ���׹̳� UI


    [Header("UI Setting")]
    public GameObject UI_Inventory;                              // �κ��丮 UI
    public GameObject UI_DetailInfo;                             // �� ���� UI
    public GameObject UI_Equipment;                             // ��� UI

    [Header("ETC")]
    public Text Text_Fillter;
    public Text Text_HavingCharacter;

    bool SteminaBool = false;


    // ĳ���� ī�� ���� ����
    public void CountCard()
    {
    }


    #region ��ư ���� UI �Լ�
    // ���׹̳� ǥ�� >> ��ư���� ��� ��
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
            Text_Fillter.text = string.Format(" ���� ���� �� ");
        }
        else
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(false);
            }
            SteminaBool = false;
            Text_Fillter.text = string.Format(" ���� ");
        }
    }

    // UI : Character_Detail_Info���� ���ĭ ������ UI : Character_Equipment Ȱ��ȭ
    public void OnClickEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }
    // ĳ���� ī�� ������>> ī��â OFF, ��â ON. ��ư���� ��� ��
    public void OnClickActiveEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }

    // ĳ���� �� ���� ��>> ��â OFF, ī��â ��. ��ư���� ��� ��
    public void OnClickExitDetailIfo()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(true);
    }

    // ��� ��ü ������ >> ���â OFF, ��â ON
    public void OnClickExitEquipment()
    {
        UI_DetailInfo.SetActive(true);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(false);
    }

    #endregion
}
