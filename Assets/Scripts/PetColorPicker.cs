using UnityEngine;
using UnityEngine.UI;

public class PetColorPicker : MonoBehaviour {
    [System.NonSerialized]
    public Color Color;

    public SpriteRenderer SR;
    public Slider RedSlider, GreenSlider, BlueSlider;

    private void Start() {
        RedSlider.SetValueWithoutNotify(Color.r);
        GreenSlider.SetValueWithoutNotify(Color.g);
        BlueSlider.SetValueWithoutNotify(Color.b);
        SR.color = Color;

        RedSlider.onValueChanged.AddListener(RedChanged);
        GreenSlider.onValueChanged.AddListener(GreenChanged);
        BlueSlider.onValueChanged.AddListener(BlueChanged);
    }
    private void OnDestroy() {
        RedSlider.onValueChanged.RemoveListener(RedChanged);
        GreenSlider.onValueChanged.RemoveListener(GreenChanged);
        BlueSlider.onValueChanged.RemoveListener(BlueChanged);
    }

    private void RedChanged(float value) {
        Color.r = value;
        SR.color = Color;
    }
    private void GreenChanged(float value) {
        Color.g = value;
        SR.color = Color;
    }
    private void BlueChanged(float value) {
        Color.b = value;
        SR.color = Color;
    }
}
