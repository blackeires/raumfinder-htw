using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownNavigationKinect : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    public void OnUpButtonClick()
    {
        int currentIndex = _dropdown.value;
        if (currentIndex != 0)
        {
            _dropdown.SetValueWithoutNotify(currentIndex - 1);
        }
    }

    public void OnDownButtonClick()
    {
        int currentIndex = _dropdown.value;
        if (currentIndex < _dropdown.options.Count); 
        {
            _dropdown.SetValueWithoutNotify(currentIndex + 1);
        }
    }

} 
