using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Bogdan"); 
    }


    public void QuitGame()
    {
        Debug.Log("Jocul se închide...");
        Application.Quit(); 
    }
}
