using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    private Renderer bumpRenderer;
    private Animator animator;
    private int currColorIndex;
    private List<Color> colorList = new List<Color>();

    private void Start()
    {
        colorList.Add(Color.green);
        colorList.Add(Color.red);
        colorList.Add(Color.yellow);

        bumpRenderer = GetComponent<Renderer>();
        bumpRenderer.material.color = color;
        animator = GetComponent<Animator>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola) {
            Debug.Log("Kena Bola");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            animator.SetTrigger("TriggerHIT");

            // add points
            GameManager.Instance.points += 10;

            // change the color to the next color in the list
            currColorIndex = (currColorIndex + 1) % colorList.Count;
            bumpRenderer.material.color = colorList[currColorIndex];
        }
    }
}
