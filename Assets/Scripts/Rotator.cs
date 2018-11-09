using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation = this.transform.rotation * Quaternion.Euler(3f, 0f, 0f);
    }
}
