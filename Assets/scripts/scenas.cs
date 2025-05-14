using UnityEngine;
using UnityEngine.SceneManagement;


public class scenas : MonoBehaviour
{
   public void menuM()
    {
        SceneManager.LoadScene("inicio");
    }

    public void gameM() 
    {
        SceneManager.LoadScene("Game");
    }
    
}
