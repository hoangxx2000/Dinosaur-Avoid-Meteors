using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    bool isGround;
    public bool IsGround { get => isGround; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb)
        {
            rb.velocity = Vector3.down * moveSpeed;
        }
    }
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Destroy(gameObject, 1f);
            GameManager.Ins.Score++;
            GameGUIManager.Ins.UpdateScoreCounting(GameManager.Ins.Score);
            AudioController.Ins.PlaySound(AudioController.Ins.landSound);
        }
    }
}
