using UnityEngine;

[RequireComponent (typeof(Collider))]
public class OrbCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Orb collected");
            GameManager.Instance.SetCurrentOrbsCollected(GameManager.Instance.GetCurrentOrbsCollected() + 1f);
            Destroy(gameObject);
        }
    }
}
