using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _camera;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _camera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }

        var res = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!res.collider) {
            return;
        }

        Debug.Log(res.collider.gameObject);
    }

}
