using System.Collections.Generic;
using UnityEngine;

public class GhostFollower : MonoBehaviour
{
    public List<Vector3> recordedPositions;
    public List<Quaternion> recordedRotations;
    private int currentStep = 0;

    void FixedUpdate()
    {
        if (currentStep < recordedPositions.Count)
        {
            transform.position = recordedPositions[currentStep];
            transform.rotation = recordedRotations[currentStep];
            currentStep++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}