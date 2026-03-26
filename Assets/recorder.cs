using System.Collections.Generic;
using UnityEngine;

public class recorder : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    private List<Quaternion> rotations = new List<Quaternion>();

    public GameObject ghostPrefab; 
    public GameObject vfxPrefab;   
    public bool isRecording = true;

    void FixedUpdate()
    {
        if (isRecording)
        {
            positions.Add(transform.position);
            rotations.Add(transform.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (positions.Count > 0)
            {
                SpawnGhost();
            }
        }
    }

    void SpawnGhost()
    {
        GameObject newGhost = Instantiate(ghostPrefab, positions[0], rotations[0]);

        GhostFollower follower = newGhost.AddComponent<GhostFollower>();
        follower.recordedPositions = new List<Vector3>(positions);
        follower.recordedRotations = new List<Quaternion>(rotations);

        if (vfxPrefab != null)
        {
            Instantiate(vfxPrefab, positions[0], Quaternion.identity);
        }   
        positions.Clear();
        rotations.Clear();
    }
}