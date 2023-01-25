using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Color _hoverColor;
    private Color _defaultColor;
    private ColorBlock _colorBlock;


    private void Start()
    {
        _colorBlock = _button.colors;
        _defaultColor = _colorBlock.selectedColor;
    }

    public void ChangeColorOnHover()
    {
        _colorBlock.selectedColor = _hoverColor;
        _button.colors = _colorBlock;
    }

    public void ChangeColorToDefault()
    {
        _colorBlock.selectedColor = _defaultColor;
        _button.colors = _colorBlock;
    }




}
