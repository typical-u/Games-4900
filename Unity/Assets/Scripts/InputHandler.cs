using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool attack_held = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack_held = true;
            Debug.Log("Attack Pressed");
        }

        if (Input.GetKey(KeyCode.Mouse0)) Debug.Log("Attack Held");

        float x = 0f;
        float y = 0f;

        if(Input.GetKey(KeyCode.A)) x-=1f;
        if(Input.GetKey(KeyCode.D)) x+=1f;
        if(Input.GetKey(KeyCode.S)) x-=1f;
        if(Input.GetKey(KeyCode.W)) x+=1f;

        Vector3 move = new Vector3(x, y, 0);
        if (move != Vector3.zero)
        {
            Debug.Log($"MOVE {move}");
            transform.position += move * 0.01f;
        }

    }
}
