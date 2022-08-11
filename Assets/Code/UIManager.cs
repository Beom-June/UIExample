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

    GameObject UI_Stemina;
    private void Update()
    {
    }

    #region ��ư ���� UI �Լ�
    // ���׹̳� ǥ�� >> ��ư���� ��� ��
    public void OnClickCheckStemina()
    {

        // ���� ���׹̳��� ���� ������
        if (SteminaBool == false)
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(true);
                //UI_Stemina.SetActive(true);
            }
            SteminaBool = true;
            Text_Fillter.text = string.Format(" 필터 중 ");
        }
        else
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {
                CharacterCard_Stemina[i].SetActive(false);
                //UI_Stemina.SetActive(false);
            }
            SteminaBool = false;
            Text_Fillter.text = string.Format(" 필터 ");
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
