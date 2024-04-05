using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int jumpCount = 2; // Maksimum zıplama sayısı
    private int currentJumpCount = 0; // Mevcut zıplama sayısı

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator anim;

    public AudioClip soundEffect1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCharacter();

        if (Input.GetKeyDown("space") && (isGrounded || currentJumpCount < jumpCount))
        {
            Jump();
            anim.SetTrigger("Jump");

            if (!isGrounded)
            {
                currentJumpCount++;
            }
        }

        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0f);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Karakterin yüzünü doğru yönde döndür
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); // Y ekseni hızını sıfırla
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            isGrounded = true;
            currentJumpCount = 0; // Yerdeyken zıplama sayısını sıfırla
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            isGrounded = false;
        }
    }

    public void GainPower(float powerAmount)
    {
        // Güç kazanma işlemleri
        if (powerAmount > 1.5f)
        {
            jumpForce += powerAmount;
            PlaySoundEffect1();
        }
        else
        {
            moveSpeed += powerAmount;
            PlaySoundEffect1();
        }
        // Burada güç kazanma sonrası ekstra işlemleri gerçekleştirebilirsiniz
    }

    void PlaySoundEffect1()
    {
        if (soundEffect1 != null)
        {
            // GameObject üzerindeki AudioSource bileşenini al
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            // Eğer AudioSource yoksa, bir tane ekleyerek al
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // AudioClip'i atayarak ses efektini oynat
            audioSource.clip = soundEffect1;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Ses efekti atanmamış!");
        }
    }
}
