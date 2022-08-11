using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class OnScreenKeyboardInputfield : MonoBehaviour, IPointerDownHandler
{
    public OnScreenKeyboard targetOnScreenKeyboard;
    public RectTransform RectKeyboard;
    private InputField _inputField;
    public string inputtedString;

    private void Awake()
    {
        _inputField = GetComponent<InputField>();

        if (_inputField == null)
            return;

        _inputField.shouldHideMobileInput = true;
    }

    public void SaveInputedString(string _inputStr)
    {
        inputtedString = _inputStr;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetOnScreenKeyboard)
        {
            targetOnScreenKeyboard.gameObject.SetActive(true);
            targetOnScreenKeyboard.ShowKeyboard(_inputField, this);

            // 키보드 위치 값 설정
            RectKeyboard.offsetMax = new Vector2(0, 5);
            RectKeyboard.offsetMin = new Vector2(0, -5);
        }
    }
}
