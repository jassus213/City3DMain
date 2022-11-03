using UnityEngine;

public class ShopController : MonoBehaviour
{
    private bool isActive = false;

    public void ShopIsActive(GameObject shopFolder)
    {
        shopFolder.SetActive(!isActive);
        isActive = !isActive;
    }
    
}

