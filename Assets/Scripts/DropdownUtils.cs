using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Class providing dropdown functionality
/// </summary>
public class DropdownUtils : MonoBehaviour
{

    /// <summary>
    /// Transforms the selected string value of a timeslot dropdown menu into an int.
    /// </summary>
    /// <param name="dd">A timeframe dropdown menu.</param>
    /// <returns>Int that corresponds to the selected timeslot string in the dropdown.</returns>
    public static int GetzeitfensterAsInt(TMP_Dropdown dd)
    {
        switch (dd.options[dd.value].text)
        {
            case "8 - 9:30 Uhr":
                return 1;
            case "9:30 - 11 Uhr":
                return 2;
            case "11 - 12:30 Uhr":
                return 3;
            case "12:30 - 14 Uhr":
                return 4;
            case "14 - 15:30 Uhr":
                return 5;
            case "15:30 - 17 Uhr":
                return 6;
            case "17 - 18:30 Uhr":
                return 7;
            case "18:30 - 20 Uhr":
                return 8;

            default:
                return 1;
        }

    }

    /// <summary>
    /// Gets the selected value from a dropdown.
    /// </summary>
    /// <param name="dd">A dropdown menu.</param>
    /// <returns>The currently selected value of the dropdown as a string.</returns>
    public static string getInputFromDropdown(TMP_Dropdown dd)
    {
        return dd.options[dd.value].text;
    }

    /// <summary>
    /// Transforms the selected string value of an equipment dropdown menu into an array.
    /// </summary>
    /// <returns>A string array consisting of the substrings of the selected string value.</returns>
    public static string[] getAusstattungAsArray(TMP_Dropdown dd)
    {
        string ausstattungStr = getInputFromDropdown(dd);
        string[] ausstattung = ausstattungStr.Split(',');
        return ausstattung;
    }

    //Function to get the char value of _kapazitaetsDropdown
    /// <summary>
    /// Transforms the selected string value of a capacity dropdown menu into an int.
    /// </summary>
    /// <param name="dd"></param>
    /// <returns>Int that corresponds to the selected capacity string in the dropdown.</returns>
    public static int getKapazitaetAsInt(TMP_Dropdown dd)
    {
        switch (dd.options[dd.value].text)
        {
            case "< 20":
                return 10;
            case "21 - 30":
                return 20;
            case "31 - 40":
                return 30;
            case "41 - 50":
                return 40;
            case "> 50":
                return 50;
            default:
                return 20;
        }

    }

    //Function to get the char value of _kapazitaetsDropdown
    /// <summary>
    /// Transforms the selected string value of a building dropdown menu into a char.
    /// </summary>
    /// <param name="dd"></param>
    /// <returns>Char that corresponds to the selected building string in the dropdown.</returns>
    public static char getGebaeudeAsChar(TMP_Dropdown dd)
    {
        string ddValue = dd.options[dd.value].text;


        switch (dd.options[dd.value].text)
        {
            case "A":
                return 'A';
            case "B":
                return 'B';
            case "C":
                return 'C';
            case "D":
                return 'D';
            case "E":
                return 'E';
            case "F":
                return 'F';
            default:
                return 'C';
        }

    }

    /// <summary>
    /// opens the passed dropdown menu
    /// </summary>
    /// <param name="dropdown"></param>
    public static void OpenDropdownMenu(TMP_Dropdown dropdown)
    {
        dropdown.Show();
    }

    /// <summary>
    /// selects the dropdown items with the passed index from the passed dropdown menu
    /// </summary>
    /// <param name="dropdown">dropdown menu from which the item should be selected</param>
    /// <param name="value">index of the dropdown item that should be selected</param>
    public static void SelectDropdownItem(TMP_Dropdown dropdown, int value)
    {
        dropdown.value = value;
        dropdown.Select();
    }


    /// <summary>
    /// gets the currently selected dropdown menu
    /// </summary>
    /// <param name="dropdowns">a list of all dropdowns on the page</param>
    /// <returns>currently selected dropdown</returns>
    public static TMP_Dropdown GetActiveDD(List<TMP_Dropdown> dropdowns) 
    {
        TMP_Dropdown activeDD = null;
        foreach (TMP_Dropdown dd in dropdowns) 
        {
            if (dd.IsActive())
            {
                activeDD = dd;
                break;
            }
        }

        return activeDD;

    }

    /// <summary>
    /// navigates up in the passed dropdown menu
    /// </summary>
    /// <param name="dropdown"></param>
    public static void navigateUpInDD(TMP_Dropdown dropdown)
    {
        int currentIndex = dropdown.value;
        if (currentIndex != 0);
        {
            dropdown.value -= 1;
            dropdown.Hide();
            dropdown.Show();
        }
    }

    /// <summary>
    /// navigates down in the passed dropdown menu
    /// </summary>
    /// <param name="dropdown"></param>
    public static void navigateDownInDD(TMP_Dropdown dropdown)
    {
        int currentIndex = dropdown.value;
        if (currentIndex < dropdown.options.Count) ;
        {
            dropdown.value += 1;
            dropdown.Hide();
            dropdown.Show();
        }
    }

}
