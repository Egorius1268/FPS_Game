using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateSpeedText();
    }

    private void Update()
    {
        UpdateSpeedText();
    }

    public void UpdateSpeedText()
    {
        text.text = $"{playerMovement.curSpeedX}";
        
    }
    
}
