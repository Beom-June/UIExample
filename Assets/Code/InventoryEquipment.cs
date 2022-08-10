using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryEquipment : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Button Setting")]
    public GameObject Btn_Total;
    public GameObject Btn_Weapon;
    public GameObject Btn_Assist;
    public GameObject Btn_Armor;
    public GameObject Btn_Glove;
    public GameObject Btn_Shoes;
    public GameObject Btn_ETC;

    public List<GameObject> BtnGroup;

    [Header("Test Setting")]
    private Transform canvas;                                               // UI�� �ҼӵǾ� �ִ� �ֻ���� Canvas Transform
    private Transform previousParent;                                       // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
    private RectTransform rect;                                             // UI ��ġ ��� ���� RectTransform
    private CanvasGroup canvasGroup;                                        // UI�� ���İ��� ��ȣ �ۿ� ��� ���� CanvasGroup

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// ���� ������Ʈ�� �巡���ϱ� ������ �� 1ȸ ȣ��
    /// </summary>
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

    /// <summary>
    /// ���� ������Ʈ�� �巡�� ���� ��, �� ������ ȣ��
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ���� >> UI�� ���콺�� �i�ƴٴϴ� ����
        rect.position = eventData.position;
    }

    /// <summary>
    /// ���� ������Ʈ�� �巡�׸� ������ ��, 1ȸ ȣ��
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        /* �巡�׸� �����ϸ� �θ� Cavnas�� ����.
         * �巡�׸� ������ ��, �θ� canvas�̸� ������ ������ �ƴ� �ٸ����� ����� �ߴٴ� ��
         * �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
         */
        if(transform.parent == canvas)
        {
            // �������� �ҼӵǾ��ִ� previousParent�� �ڽ����� ����. �ش� ��ġ�� ����
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        // ���� ���� 1�� ����. ���� �浹 ó���� �ǵ��� ��
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}