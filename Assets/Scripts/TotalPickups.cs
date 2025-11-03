using TMPro;
using UnityEngine;

public class TotalPickups : MonoBehaviour
{
    GameManager gameManager;
    public TMP_Text textDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text = "Total Pickups: " + gameManager.PickupCount.ToString() + "/" + gameManager.MaxPickup.ToString();
    }
}
