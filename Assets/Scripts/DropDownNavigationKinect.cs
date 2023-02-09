using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// class for the alternative kinect dropdown controls
/// </summary>
public class DropDownNavigationKinect : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    /// <summary>
    /// navigates to the previous dropdown item 
    /// </summary>
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

    /// <summary>
    /// navigates to the following dropdown item
    /// </summary>
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

    /// <summary>
    /// chooses the selected dropdown item and closes the dropdown menu
    /// </summary>
    public void OnSubmitButtonClick()
    {
        _dropdown.Hide();
    }



} 
