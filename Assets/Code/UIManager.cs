using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> CharacterCard = new List<GameObject>();                                         // 캐릭터 카드 
    public List<GameObject> CharacterCard_Stemina;// = new List<GameObject>();                              // 캐릭터 스테미나 UI


    [Header("UI Setting")]
    public GameObject UI_Inventory;                              // 인벤토리 UI
    public GameObject UI_DetailInfo;                             // 상세 정보 UI
    public GameObject UI_Equipment;                             // 장비 UI

    [Header("ETC")]
    public Text Text_Fillter;
    public Text Text_HavingCharacter;

    bool SteminaBool = false;


    // 캐릭터 카드 개수 세기
    public void CountCard()
    {
    }


    #region 버튼 관련 UI 함수
    // 스테미나 표시 >> 버튼에서 사용 중
    public void OnClickCheckStemina()
    {
        //CharacterCard_Stemina[currentActiveIndex].SetActive(false);

        //currentActiveIndex++;

        //if (currentActiveIndex >= CharacterCard_Stemina.Count)
        //{
        //    currentActiveIndex = 0;
        //}

        // 만약 스테미나가 꺼져 있으면
        if (SteminaBool == false)
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(true);
            }
            SteminaBool = true;
            Text_Fillter.text = string.Format(" 필터 적용 중 ");
        }
        else
        {
            for (int i = 0; i < CharacterCard_Stemina.Count; i++)
            {

                CharacterCard_Stemina[i].SetActive(false);
            }
            SteminaBool = false;
            Text_Fillter.text = string.Format(" 필터 ");
        }
    }

    // UI : Character_Detail_Info에서 장비칸 누르면 UI : Character_Equipment 활성화
    public void OnClickEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }
    // 캐릭터 카드 누를시>> 카드창 OFF, 상세창 ON. 버튼에서 사용 중
    public void OnClickActiveEquipment()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(true);
        UI_Inventory.SetActive(false);
    }

    // 캐릭터 상세 누를 시>> 상세창 OFF, 카드창 켬. 버튼에서 사용 중
    public void OnClickExitDetailIfo()
    {
        UI_DetailInfo.SetActive(false);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(true);
    }

    // 장비 교체 누를시 >> 장비창 OFF, 상세창 ON
    public void OnClickExitEquipment()
    {
        UI_DetailInfo.SetActive(true);
        UI_Equipment.SetActive(false);
        UI_Inventory.SetActive(false);
    }

    #endregion
}
