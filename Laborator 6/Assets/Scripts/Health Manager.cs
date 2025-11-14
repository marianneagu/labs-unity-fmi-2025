using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    // In our case we have health only on Player
    public static HealthManager Instance;

    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Slider healthbarSlider;

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

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthbarSlider.value = currentHealth;
    }

    public void GetDamage(bool killInstantly = false)
    {
        if (killInstantly) 
        {
            currentHealth = 0;
            return;
        }

        currentHealth -= damage;

        Debug.Log($"Got damage. Health: {currentHealth}/{maxHealth}");

        if(!IsAlive())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }


    public void Heal()
    {
        currentHealth = maxHealth;
        Debug.Log($"Health increased to maximum value: {currentHealth}/{maxHealth}");
    }
}
