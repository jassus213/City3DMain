using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string _loadingScene = "GameScene";


    public void OpenFolder(GameObject folder)
    {
        folder.SetActive(true);
    }

    public void HideFolder(GameObject folder)
    {
        folder.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(_loadingScene);
    }
}