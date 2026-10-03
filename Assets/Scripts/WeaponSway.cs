using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    
    public float smooth;
    public float swayMultiplier;

    Vector2 MouseVector;

    public void SetLookInput(Vector2 input)
    {
        MouseVector = input;
    }

    void Update()
    {
        float mouseX = MouseVector.x * swayMultiplier;
        float mouseY = MouseVector.y * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
