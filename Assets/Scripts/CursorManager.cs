using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Panggil fungsi pengunci saat game dimulai
        LockCursor();
    }

    void Update()
    {
        // FITUR PENTING: Tombol darurat buat munculin kursor lagi
        // Tekan ESC untuk membatalkan kunci (biar bisa close game/pause)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        // Opsional: Klik kiri buat kunci lagi kalau habis tekan ESC
        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        // 1. Mengunci kursor di tengah layar
        Cursor.lockState = CursorLockMode.Locked;

        // 2. Menghilangkan kursor (Invisible)
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        // Melepaskan kursor (Bebas gerak)
        Cursor.lockState = CursorLockMode.None;

        // Memunculkan kursor lagi
        Cursor.visible = true;
    }
}