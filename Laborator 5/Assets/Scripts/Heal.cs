using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HealthManager.Instance.Heal();
            Destroy(gameObject);
        }
    }
}
