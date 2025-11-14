using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int minOrbsToWin;

    private int currentOrbsCollected;

    [SerializeField]
    private GameObject pauseMenu;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
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


    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
