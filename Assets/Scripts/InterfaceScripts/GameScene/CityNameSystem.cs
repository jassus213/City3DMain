using TMPro;
using UnityEngine;

public class CityNameSystem : MonoBehaviour
{
    private string _nameOfCity = "CityName";
    
    [SerializeField] private TextMeshProUGUI cityNameText;

    public void SaveCityName(TMP_InputField Text)
    {
        _nameOfCity = Text.text;
        cityNameText.text = _nameOfCity;
    }

    public void CloseCityNameWindow(GameObject Window)
    {
        Destroy(Window);
    }
}
