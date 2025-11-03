using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    public int PickupCount = 0;

    [SerializeField] GameObject[] QualityItems;
    [SerializeField] Timer timer;
    [SerializeField] GameObject[] Pickups;
    [SerializeField] public int MaxPickup = 0;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject[] PauseMenuButtons;
    [SerializeField] private float doorMoveDuration = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 DoorOpenPosition;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        DoorOpenPosition = new Vector3(-7.54f, 0.974f, 4f);
        
        Time.timeScale = 1f;
        isPaused = false;
        
        
            PauseMenuButtons[0].SetActive(false);
            PauseMenuButtons[1].SetActive(false);
            PauseMenuButtons[2].SetActive(false);
            PauseMenuButtons[3].SetActive(false);
            PauseMenuButtons[4].SetActive(false);
        
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    private void LateUpdate()
    {
        if (PickupCount >= MaxPickup)
        {
            Door.transform.position = Vector3.SmoothDamp(
                Door.transform.position, 
                DoorOpenPosition, 
                ref velocity, 
                doorMoveDuration
            );
        }

        
    }

    public void TogglePauseState(bool value)
    {
        if (value)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused) return;

        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Game Paused");

        
            PauseMenuButtons[0].SetActive(true);
            PauseMenuButtons[1].SetActive(true);
            PauseMenuButtons[2].SetActive(true);
            PauseMenuButtons[3].SetActive(true);
            PauseMenuButtons[4].SetActive(true);

        
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        if (!isPaused) return;

        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Game Resumed");
        
        
            PauseMenuButtons[0].SetActive(false);
            PauseMenuButtons[1].SetActive(false);
            PauseMenuButtons[2].SetActive(false);
            PauseMenuButtons[3].SetActive(false);
            PauseMenuButtons[4].SetActive(false);
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        timer.countdownTime = 60;
        foreach(var Pickup in Pickups)
        {
            Pickup.SetActive(true);
        }
        PickupCount = 0;
        Player.SetActive(false);
        Player.transform.position = new Vector3(-5f, 0.5f, 2f);
        Player.SetActive(true);
    }

    public void QualityReduce()
    {
        foreach ( var Quality in QualityItems)
        {
            Quality.SetActive(false);
        }
    }

 
    public void QualityIncrease()
    {
        foreach (var Quality in QualityItems)
        {
            Quality.SetActive(true);
        }
    }
}