using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void StartGameScene(){
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame(){
        Application.Quit();
    }    
}
