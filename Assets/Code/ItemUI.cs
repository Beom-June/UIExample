using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // ������ UI ����
    private Transform canvas;                                               // UI�� �ҼӵǾ� �ִ� �ֻ���� Canvas Transform
    private Transform previousParent;                                       // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
    private RectTransform rect;                                             // UI ��ġ ��� ���� RectTransform
    private CanvasGroup canvasGroup;                                        // UI�� ���İ��� ��ȣ �ۿ� ��� ���� CanvasGroup

    // ������ ����
    #region ������ ���� enum ��
    // ������ Ÿ��
    public enum E_Type
    {
        Weapon,
        Helmnet,
        Gauntlet,
        Boots,
        Jewelry
    };
    // ������ ���
    public enum E_Grade
    {
        Normal,
        Rare,
        Epic,
        Legend,
        Myth
    };
    #endregion
    public E_Grade EquipGrade = E_Grade.Normal;                                              // ������ ���
    public E_Type EquipType = E_Type.Boots;                                                // ������ Ÿ��

    public GameObject tooltip;                                              // ������ ���� (Tooltip)
    public Text Item_Grade;                                                  // ������ ��� UI
    public Text Item_Name;                                                  // ������ �̸� UI
    public Text Item_State;                                                 // ������ �ɷ�ġ UI
    public Text Item_Explain;                                               // ������ ���� UI

    public string Grade;                                                     // ������ ���
    public string Name;                                                     // ������ �̸�
    public string State;                                                    // ������ �ɷ�ġ
    public string Explain;                                                  // ������ ����

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

    #region ���콺 ���콺 ������, ���� ����
    public void ShowTooltip()
    {
        tooltip.SetActive(true);
        //Debug.Log("Item" + transform.GetSiblingIndex());
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    // ���콺 Ŀ���� Slot ���� ������ ������ ȣ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    // ���콺 Ŀ���� Slot ���� �ȿ��� ������ ������ ȣ��
    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
    }
    #endregion

    #region ������ �巡�� ����
    /// ���� ������Ʈ�� �巡���ϱ� ������ �� 1ȸ ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ������ �ҼӵǾ� �ִ� �θ� Transform ���� ����
        previousParent = transform.parent;

        // ���� �巡������ UI�� ȭ���� �ֻ�ܿ� ��� �ǵ��� �ϱ� ����
        transform.SetParent(canvas);                                                    // �θ� ������Ʈ�� Canvas�� ����
        transform.SetAsLastSibling();                                                   // ���� �տ� ���̵��� ������ �ڽ����� ����

        // �巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ ���� �� �ֱ� ������, CanvasGroup���� ����
        // ���İ� 0.6���� ����. ���� �浹 ó���� ���� �ʵ��� ��
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    /// ���� ������Ʈ�� �巡�� ���� ��, �� ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ���� >> UI�� ���콺�� �i�ƴٴϴ� ����
        rect.position = eventData.position;
    }

    /// ���� ������Ʈ�� �巡�׸� ������ ��, 1ȸ ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {
        /* �巡�׸� �����ϸ� �θ� Cavnas�� ����.
         * �巡�׸� ������ ��, �θ� canvas�̸� ������ ������ �ƴ� �ٸ����� ����� �ߴٴ� ��
         * �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
         */
        if (transform.parent == canvas)
        {
            // �������� �ҼӵǾ��ִ� previousParent�� �ڽ����� ����. �ش� ��ġ�� ����
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        // ���� ���� 1�� ����. ���� �浹 ó���� �ǵ��� ��
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
    #endregion
}
