using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        bool objectIsOutOfBounds = gameObject.CompareTag("OutOfBounds");
        if(collision.gameObject.CompareTag("Player"))
        {
            HealthManager.Instance.GetDamage(objectIsOutOfBounds);
            
        }
    }
}
