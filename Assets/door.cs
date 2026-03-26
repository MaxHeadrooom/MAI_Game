using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 5, 0); 
    private Vector3 closedPosition;
    private bool isOpen = false;

    void Start() { closedPosition = transform.position; }

    void Update()
    {
        Vector3 targetPos = isOpen ? closedPosition + openOffset : closedPosition;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
    }

    public void SetOpen(bool open) { isOpen = open; }
}