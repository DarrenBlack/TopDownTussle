using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //Find offset between camera and player
        offset = transform.position - player.transform.position;
    }

    // Called after update each frame
    void LateUpdate()
    {
        //Update camera position according to player position
        transform.position = player.transform.position + offset;
    }
}
