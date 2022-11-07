using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityNameSystem : MonoBehaviour
{
    private string _nameOfCity = "CityName";
    
    [SerializeField] private TextMeshProUGUI _CityNameText;

    public void SaveCityName(TMP_InputField Text)
    {
        _nameOfCity = Text.text;
        _CityNameText.text = _nameOfCity;
    }

    public void CloseCityNameWindow(GameObject Window)
    {
        Window.SetActive(false);
    }
}
