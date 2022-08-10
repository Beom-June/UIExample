using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryEquipment : MonoBehaviour
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

}
