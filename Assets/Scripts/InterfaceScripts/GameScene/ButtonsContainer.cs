using UnityEngine;

public class ButtonsContainer : MonoBehaviour
{
    public void ChangeStatus(GameObject folder, bool status)
    {
        folder.SetActive(status);
    }

}
