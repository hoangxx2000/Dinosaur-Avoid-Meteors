using UnityEngine;

public class Dino : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Animator amin;
    bool isDead;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (isDead && rb) rb.velocity = new Vector2(0f, rb.velocity.y);
        if (isDead || !GameManager.Ins.IsGamebegin) return;
        MoveHandle();
    }
    private void Update()
    {
        if (isDead || !GameManager.Ins.IsGamebegin) return;
        Flip();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f, 9f), transform.position.y, transform.position.z);
    }
    void MoveHandle()
    {
        if (GamePadsController.Ins.CanMoveLeft)
        {
            if (rb)
                rb.velocity = new Vector2(-1f, rb.velocity.y) * moveSpeed;
            if (amin)
                amin.SetBool("Run", true);
        }
        else if (GamePadsController.Ins.CanMoveRight)
        {
            if (rb)
                rb.velocity = new Vector2(1f, rb.velocity.y) * moveSpeed;
            if (amin)
                amin.SetBool("Run", true);
        }
        else 
        {
            if (rb)
                rb.velocity = new Vector2(0, rb.velocity.y);
            if (amin)
                amin.SetBool("Run", false);
        }
    }
    void Flip()
    {
        if (GamePadsController.Ins.CanMoveLeft)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }else if (GamePadsController.Ins.CanMoveRight)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    void Die()
    {
        isDead = true;
        if (amin)
            amin.SetTrigger("Dead");
        if (rb)
            rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            if (isDead) return;
            Stone stone = collision.gameObject.GetComponent<Stone>();
            if (stone && !stone.IsGround)
            {
                Die();
                GameManager.Ins.IsGameover = true;
                GameGUIManager.Ins.ShowGameOver(true);
                AudioController.Ins.PlaySound(AudioController.Ins.loseSound);
                AudioController.Ins.PlaySound(AudioController.Ins.landSound);
            }
        }
    }
}
