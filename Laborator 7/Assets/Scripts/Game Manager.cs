using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int minOrbsToWin;

    private int currentOrbsCollected;

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

        currentOrbsCollected = 0;
    }


    public void AddPoint()
    {
        currentOrbsCollected++;
        Debug.Log($"Current orbs: {currentOrbsCollected}");
    }

    public bool MinOrbsToWinCollected()
    {
        return currentOrbsCollected >= minOrbsToWin;
    }

    public int GetCurrentOrbs()
    {
        return currentOrbsCollected;    
    }

    public void StartGame()
    {

    }

    public void LoadGame()
    {

    }

    public void PauseGame()
    {

    }

}
