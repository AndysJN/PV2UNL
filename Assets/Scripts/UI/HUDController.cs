using UnityEngine;
using TMPro;
public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextToModify;

    public void UpdateText(string InText)
    {
        TextToModify.text = InText;
    }
    
    public void UpdateTextAsInt(int InText)
    {
        TextToModify.text = InText.ToString();
    }
}
