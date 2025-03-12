using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextScript : MonoBehaviour
{
    public TextMeshProUGUI NumberText;
    private Slider _slider;

    public void SetNumberText(float value)
    {
        NumberText.text = value.ToString();
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        SetNumberText(_slider.value);
    }
}
