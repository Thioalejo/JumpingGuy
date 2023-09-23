using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public Animator animator;
    public bool enemyCollision = false, grounded;
    float startY;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
       grounded = transform.position.y == startY;
    }

    public void SetAnimation(string name)
    {
        animator.Play(name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyCollision = true;
            //Para evitar que sume puntos al tocar un enemigo luego de morir
            GetComponent<BoxCollider2D>().enabled = false;
            AudioManager.Instance.PlaySound("Die");
            AudioManager.Instance.StopMusic();
        }
        else if (collision.tag == "Points")
        {
            ScoreManager.Instance.IncreasePoints();
            AudioManager.Instance.PlaySound("Point");
        }

    }
}
