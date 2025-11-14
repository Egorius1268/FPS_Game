using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour
{
    public Gun gun;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateAmmoText();
    }

    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"{gun.currentClip} / {gun.maxClipSize}<br><size=70%>{gun.currentAmmo} / {gun.maxAmmoSize}";
        
    }
    
}
