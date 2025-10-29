using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField]
    private float orbsToWin;
    [SerializeField]
    private float currentOrbsCollected;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetOrbsToWin()
    {
        return orbsToWin;
    }

    public float GetCurrentOrbsCollected()
    {
        return currentOrbsCollected;
    }

    public void SetCurrentOrbsCollected(float newValue)
    {
        currentOrbsCollected = newValue;
    }
    
}
