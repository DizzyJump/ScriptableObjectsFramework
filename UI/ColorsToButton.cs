using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsToButton : MonoBehaviour
{
    Button Button;
    public ColorValue NormalColor;
    public ColorValue DisabledColor;

    private void OnEnable()
    {
        if(Button == null)
            Button = GetComponent<Button>();
        if(NormalColor != null)
        {
            NormalColor.AddHandler(OnChangeNormalValue);
        }
        OnChangeNormalValue();

        if(DisabledColor !=null)
        {
            DisabledColor.AddHandler(OnChangeDisableValue);
        }
        OnChangeDisableValue();
    }

    private void OnDisable()
    {
        if(NormalColor != null)
            NormalColor.RemoveHandler(OnChangeNormalValue);
        if(DisabledColor != null)
            DisabledColor.RemoveHandler(OnChangeDisableValue);
    }

    void OnChangeNormalValue()
    {
        if(Button != null && NormalColor != null)
        {
            var colors = Button.colors;
            colors.normalColor = NormalColor.Value;
            colors.highlightedColor = NormalColor.Value;
            colors.pressedColor = NormalColor.Value;
            Button.colors = colors;
        }
    }

    void OnChangeDisableValue()
    {
        if(Button != null && DisabledColor != null)
        {
            var colors = Button.colors;
            colors.disabledColor = DisabledColor.Value;
            Button.colors = colors;
        }
    }
}
