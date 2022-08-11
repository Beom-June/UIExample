using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 아이템 UI 세팅
    private Transform canvas;                                               // UI가 소속되어 있는 최상단의 Canvas Transform
    private Transform previousParent;                                       // 해당 오브젝트가 직전에 소속되어 있었던 부모 Transform
    private RectTransform rect;                                             // UI 위치 제어를 위한 RectTransform
    private CanvasGroup canvasGroup;                                        // UI의 알파값과 상호 작용 제어를 위한 CanvasGroup

    // 아이템 세팅
    #region 아이템 설정 enum 값
    // 아이템 타입
    public enum E_Type
    {
        Weapon,
        Helmnet,
        Gauntlet,
        Boots,
        Jewelry
    };
    // 아이템 등급
    public enum E_Grade
    {
        Normal,
        Rare,
        Epic,
        Legend,
        Myth
    };
    #endregion
    public E_Grade EquipGrade = E_Grade.Normal;                                              // 아이템 등급
    public E_Type EquipType = E_Type.Boots;                                                // 아이텝 타입

    public GameObject tooltip;                                              // 아이템 정보 (Tooltip)
    public Text Item_Grade;                                                  // 아이템 등급 UI
    public Text Item_Name;                                                  // 아이템 이름 UI
    public Text Item_State;                                                 // 아이템 능력치 UI
    public Text Item_Explain;                                               // 아이템 설명 UI

    public string Grade;                                                     // 아이템 등급
    public string Name;                                                     // 아이템 이름
    public string State;                                                    // 아이템 능력치
    public string Explain;                                                  // 아이템 설명

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        Item_InfoSet();
    }

    void Item_InfoSet()
    {
        Item_Name.text = Name;
        Item_State.text = State;
        Item_Explain.text = Explain;

        Item_Grade.text = Grade;
        // Normal
        if (EquipGrade == E_Grade.Normal)
        {
        }
    }

    #region 마우스 마우스 오버시, 정보 띄우기
    public void ShowTooltip()
    {
        tooltip.SetActive(true);
        //Debug.Log("Item" + transform.GetSiblingIndex());
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    // 마우스 커서가 Slot 영역 안으로 들어오면 호출
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    // 마우스 커서가 Slot 영역 안에서 밖으로 나가면 호출
    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }
    #endregion

    #region 아이템 드래그 관련
    /// 현재 오브젝트를 드래그하기 시작할 때 1회 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 직전에 소속되어 있던 부모 Transform 정보 저장
        previousParent = transform.parent;

        // 현재 드래그중인 UI가 화면의 최상단에 출력 되도록 하기 위해
        transform.SetParent(canvas);                                                    // 부모 오브젝트를 Canvas로 설정
        transform.SetAsLastSibling();                                                   // 가장 앞에 보이도록 마지막 자식으로 설정

        // 드래그 가능한 오브젝트가 하나가 아닌 자식들을 가지고 있을 수 있기 때문에, CanvasGroup으로 통제
        // 알파값 0.6으로 설정. 광선 충돌 처리가 되지 않도록 함
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    /// 현재 오브젝트를 드래그 중일 때, 매 프레임 호출
    public void OnDrag(PointerEventData eventData)
    {
        // 현재 스크린상의 마우스 위치를 UI 위치로 설정 >> UI가 마우스를 쫒아다니는 상태
        rect.position = eventData.position;
    }

    /// 현재 오브젝트의 드래그를 종료할 때, 1회 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        /* 드래그를 시작하면 부모가 Cavnas로 설정.
         * 드래그를 종료할 때, 부모가 canvas이면 아이템 슬롯이 아닌 다른곳에 드랍을 했다는 뜻
         * 드래그 직전에 소속되어 있던 아이템 슬롯으로 아이템 이동
         */
        if (transform.parent == canvas)
        {
            // 마지막에 소속되어있던 previousParent의 자식으로 설정. 해당 위치로 설정
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        // 알파 값을 1로 설정. 광선 충돌 처리가 되도록 함
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
    #endregion
}
