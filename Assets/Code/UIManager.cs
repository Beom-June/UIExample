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

    #region 클릭 UI 관련
    // 스테미나 버튼 클릭시
    public void OnClickCheckStemina()
    {

        // 누르면
        if (SteminaBool == false)
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(true);
                //UI_Stemina[i].SetActive(true);
            }
            SteminaBool = true;
            Text_Fillter.text = string.Format(" 필터 중 ");
        }
        else
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {
                CharacterCard_Stemina[i].SetActive(false);
                //UI_Stemina[i].SetActive(false);
            }
            SteminaBool = false;
            Text_Fillter.text = string.Format(" 필터 ");
        }
    }

    public void OnClickEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }
    public void OnClickActiveEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }

    public void OnClickExitDetailIfo()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(true);
    }

    public void OnClickExitEquipment()
    {
        UI_DetailInfo.SetActive(true);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(false);
    }

    #endregion
}
