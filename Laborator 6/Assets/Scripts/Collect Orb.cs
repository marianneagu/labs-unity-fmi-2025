using UnityEngine;

public class CollectOrb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            GameManager.Instance.AddPoint();
            Destroy(gameObject);
        }
    }
}
