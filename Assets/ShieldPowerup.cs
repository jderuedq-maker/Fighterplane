using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.down * 3f * Time.deltaTime);
        if (transform.position.y < -7f)
            Destroy(gameObject);
    }
}