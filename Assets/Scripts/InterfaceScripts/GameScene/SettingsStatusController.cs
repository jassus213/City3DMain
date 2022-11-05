using UnityEngine;



public class SettingsStatusController : MonoBehaviour
{
    [SerializeField] private GameObject _settingsFolder;

    private bool _settingsFolderIsActive = false;
    private bool _gameStatus = true;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGameActive())
           {
               ChangeGameStatus();
               _settingsFolderIsActive = true;
               _settingsFolder.SetActive(true);
               
           }
           else if(isGameActive())
           {
               ChangeGameStatus();
               _settingsFolderIsActive = false;
               _settingsFolder.SetActive(false);
           }
        }
    }

    private void ChangeGameStatus()
    {
        _gameStatus =  !_gameStatus;
    }

    private bool isGameActive()
    {
        if (_gameStatus)
        {
            return true;
        }

        return false;
    }
}
