using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && 
            GameManager.Instance.GetCurrentOrbsCollected() == GameManager.Instance.GetOrbsToWin())
        {
            SceneManager.LoadScene("Level 2");
            
        }
    }

    
}
