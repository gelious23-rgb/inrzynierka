using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown1;
    [SerializeField]
    private TMP_Dropdown dropdown2;
    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;

    private void Start()
    {
        // Przypisanie metod do zdarzeñ OnValueChanged dla obu dropdownów
        dropdown1.onValueChanged.AddListener(OnDropdown1ValueChanged);
        dropdown2.onValueChanged.AddListener(OnDropdown2ValueChanged);
    }

    private void OnDropdown1ValueChanged(int index)
    {
        // Sprawdzenie wybranej opcji w dropdownie 1
        string selectedOption = dropdown1.options[index].text;

        // Zmiana koloru obrazka w zale¿noœci od wyboru
        if (selectedOption == "Angels")
        {
            image1.color = Color.blue; // Zmiana koloru obrazka dla dropdownu 1
        }
        else if (selectedOption == "Demons")
        {
            image1.color = Color.red; // Zmiana koloru obrazka dla dropdownu 1
        }
    }

    private void OnDropdown2ValueChanged(int index)
    {
        // Sprawdzenie wybranej opcji w dropdownie 2
        string selectedOption = dropdown2.options[index].text;

        // Zmiana koloru obrazka w zale¿noœci od wyboru
        if (selectedOption == "Angels")
        {
            image2.color = Color.blue; // Zmiana koloru obrazka dla dropdownu 2
        }
        else if (selectedOption == "Demons")
        {
            image2.color = Color.red; // Zmiana koloru obrazka dla dropdownu 2
        }
    }
}
