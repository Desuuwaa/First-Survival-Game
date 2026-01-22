using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Drag objek Player (induk) ke sini
    public Transform cameraRoot; // Drag objek CameraRoot (kepala) ke sini

    float xRotation = 0f;

    void Update()
    {
        // 1. Ambil Input Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 2. Hitung Rotasi Atas-Bawah (Nunduk/Dongak) - HANYA KEPALA
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Batasi biar gak patah leher

        // Terapkan ke CameraRoot (Kepala)
        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 3. Hitung Rotasi Kiri-Kanan - SELURUH BADAN
        playerBody.Rotate(Vector3.up * mouseX);
    }
}