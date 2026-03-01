using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler_New : MonoBehaviour
{
    public MyInputSystem_Actions input;
    private bool attackHeld = false;

    private void Start()
    {

    }
    private void OnEnable()
    {
        input = new MyInputSystem_Actions();
        input.Player.Enable();

        input.Player.Attack.performed += AttackPressed;
        input.Player.Attack.started += _ => attackHeld = true;
        input.Player.Attack.canceled += AttackReleased;
    }

    private void OnDisable()
    {
        input.Player.Attack.performed -= AttackPressed;
        input.Player.Attack.canceled -= AttackReleased;
        input.Player.Disable();
    }

    private void Update()
    {
        if (attackHeld) Debug.Log("Attack Held");

        Vector2 move = input.Player.Move.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            transform.position += new Vector3(move.x, move.y, 0) * 0.01f;
        }
    }
    private void AttackPressed(InputAction.CallbackContext _) => Debug.Log("Attack Pressed");

    private void AttackReleased(InputAction.CallbackContext _)
    {
        attackHeld = false;
        Debug.Log("Attack Released");
    }
}