using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Kita bikin private saja, biar otomatis cari kamera
    private Transform cam;

    void Start()
    {
        // Otomatis cari Main Camera (Cinemachine Brain menempel di sini)
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        // RUMUS AJAIB:
        // "Arah depanku = Arah depan kamera"
        transform.forward = cam.forward;
    }
}