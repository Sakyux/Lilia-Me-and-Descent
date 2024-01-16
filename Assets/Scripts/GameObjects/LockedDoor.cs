using UnityEngine;
[System.Serializable]
public class LockedDoor : MonoBehaviour
{
    public Collider2D Collider2D;
    public KeyItems keyItems;
    public Sprite unlockedSprite, lockedSprite;
    public SpriteRenderer Door;
    public int requiredKeyID, doorNum;
    private bool playerNear;
    private bool open = false, compare = true;
    public DoorManager doorManager;
    public GameLog gameLog;

    private void Start()
    {
        Collider2D = transform.Find("LockedDoor").GetComponent<Collider2D>();
        keyItems = GameObject.Find("KeyItems").GetComponent<KeyItems>();
        doorManager = GameObject.Find("DoorManager").GetComponent<DoorManager>();
        Door = transform.Find("LockedDoor").GetComponent<SpriteRenderer>();
        gameLog = GameObject.Find("GameLog").GetComponent<GameLog>();
    }
    void Update()
    {
        if (DoorManager.Instance.DoorList[doorNum - 1].isActive != compare)
        {
            Collider2D.isTrigger = !DoorManager.Instance.DoorList[doorNum - 1].isActive;
            compare = DoorManager.Instance.DoorList[doorNum - 1].isActive;
            Debug.Log("Changed Door State");
            if (DoorManager.Instance.DoorList[doorNum - 1].isActive)
            {
                LockDoor();
                open = false;
            }
        }
        TryItem();
    }
    public void TryItem()
    {
        if (!open && playerNear && Input.GetButtonDown("confirm" + Options.controlOpt))
        {
            if (keyItems.heldItem == requiredKeyID && !open)
            {
                DoorManager.Instance.DoorList[doorNum - 1].isActive = false;
                UnlockDoor();
                open = true;
            }
            else if (keyItems.heldItem != 0 && !open) gameLog.AddEvent("This is the wrong item.");
        }

    }
    private void UnlockDoor()
    {
        Collider2D.isTrigger = true;
        Door.sprite = unlockedSprite;
        keyItems.UseItem(keyItems.heldItem);
    }

    private void LockDoor()
    {
        Collider2D.isTrigger = false;
        Door.sprite = lockedSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

}
