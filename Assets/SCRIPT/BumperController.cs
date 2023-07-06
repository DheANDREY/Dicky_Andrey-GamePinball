using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;
    public float multiplier;
    // untuk mengatur warna bumper
    public Color color;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        // karena material ada pada component Rendered, maka kita ambil renderernya
        renderer = GetComponent<Renderer>();

        // kita akses materialnya dan kita ubah warna nya saat Start
        renderer.material.color = color;

        // ambil animatornya saat Start
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if(collision.collider == bola)
        {
            // kita lakukan debug
            Debug.Log("Kena Bola");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            animator.SetTrigger("TriggerHIT");
        }
    }
}
