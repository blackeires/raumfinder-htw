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
            _dropdown.value -= 1;
            _dropdown.Hide();
            _dropdown.Show();
        }
    }

    public void OnDownButtonClick()
    {
        int currentIndex = _dropdown.value;
        if (currentIndex < _dropdown.options.Count); 
        {
            _dropdown.value += 1;
            _dropdown.Hide();
            _dropdown.Show();
        }
    }

} 
