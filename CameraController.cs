using UnityEngine;

public class CameraController : MonoBehaviour
{
    // reference player game object
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // calculate intial offset between cameras position and players position
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //maintain the same offset between the camera and player through out the game
    }
}
