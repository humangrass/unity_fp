using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float _xRotation = 0f;

    public Camera cam;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    // Start is called before the first frame update
    public void ProcessLook(Vector2 input)
    {
        var mouseX = input.x;
        var mouseY = input.y;
        // calculate camera for looking up and down
        _xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
        // apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        // rotate player to look left and right
        transform.Rotate((mouseX * Time.deltaTime) * xSensitivity * Vector3.up);
    }
}