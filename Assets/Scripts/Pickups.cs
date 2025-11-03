using UnityEngine;
using UnityEngine.VFX;

public class Pickups : MonoBehaviour
{
    [SerializeField] AudioClip AudioClip;
    GameManager gameManager;
    [SerializeField] GameObject VFXGameobject;
    
    private void Start()
    {
        
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
      
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            VFXGameobject.GetComponent<VisualEffect>().Play();
            gameManager.PickupCount++;
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(AudioClip, transform.position);
        }
    }

}
