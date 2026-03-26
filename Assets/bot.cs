using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorController door;
    private int objectsOnButton = 0;

    private void OnTriggerEnter(Collider foreign)
    {
        objectsOnButton++;
        door.SetOpen(true);
    }

    private void OnTriggerExit(Collider foreign)
    {
        objectsOnButton--;
        if (objectsOnButton <= 0) door.SetOpen(false);
    }
}