using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") &&
            GameManager.Instance.MinOrbsToWinCollected())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
