using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager Instance;
    [SerializeField]
    private int hitValue;

    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentHealth = maxHealth;
    }

    public void HitObject()
    {
        currentHealth -= hitValue;
        Debug.Log($"Health: {currentHealth}/{maxHealth}");
    }

    public void Heal()
    {
        currentHealth += hitValue;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    
    public int GetHitValue()
    {
        return hitValue;
    }
   

}
