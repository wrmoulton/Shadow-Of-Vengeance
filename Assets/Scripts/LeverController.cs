using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Animator leverAnimator;
    public Sprite idleSprite; // Set this in the Inspector (the upright lever frame)
    public GameObject laserToDisable; // Assign a single laser GameObject

    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
    private bool used = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;

        leverAnimator.enabled = false;
    }

  void Update()
{
    if (playerInRange && !used && Input.GetKeyDown(KeyCode.E))
    {
        used = true;

        leverAnimator.enabled = true;
        leverAnimator.SetTrigger("Pull");

        // Disable the entire laser GameObject
        if (laserToDisable != null)
        {
            laserToDisable.SetActive(false);
        }
    }
}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
