using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    public float speed = 6.0F;

    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update for Movement in Physics controller
    void FixedUpdate()
    {
        float xStart = player.transform.position.x;
        float yStart = player.transform.position.y;
        float zStart = player.transform.position.z;

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 1.5f, Input.GetAxisRaw("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        player.MovePosition(moveDirection);
        //player.translate(moveDirection * Time.deltaTime);
        //player.transform.position = moveDirection;

    }


}