using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealthManager.Instance.HitObject();

            if(!HealthManager.Instance.IsAlive())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
