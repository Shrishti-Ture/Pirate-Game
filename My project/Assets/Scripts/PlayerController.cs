
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    ShipMovement movement;

    void Awake()
    {
        movement = GetComponent<ShipMovement>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");

        movement.Move(move, turn);
    }
}