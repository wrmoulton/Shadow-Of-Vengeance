using UnityEngine;

public class LinkedLever : MonoBehaviour
{
    public Animator leverAnimator;
    public Sprite idleSprite;
    public GameObject objectToDisable; // e.g. capsule lid
    public GameObject objectToEnable;  // e.g. keycard
    public string playerTag = "Player";

    private static int totalLeversPulled = 0;
    private static int requiredLevers = 3;
    private static bool puzzleTriggered = false;

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

            totalLeversPulled++;
            CheckPuzzleSolved();
        }
    }

    void CheckPuzzleSolved()
    {
        if (puzzleTriggered) return;

        if (totalLeversPulled >= requiredLevers)
        {
            puzzleTriggered = true;

            if (objectToDisable != null)
                objectToDisable.SetActive(false);

            if (objectToEnable != null)
                objectToEnable.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            playerInRange = false;
    }
}
