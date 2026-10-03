using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;
    public float speed;
    public bool vertical;
    Rigidbody2D rigidbody2d;
    void Start()
{
    rigidbody2d = GetComponent<Rigidbody2D>();
    timer = changeTime;
}
    void Update()
{
    timer -= Time.deltaTime;
    if (timer < 0)
    {
    direction = -direction;
    timer = changeTime;
    }
}
    void FixedUpdate()
{
    
    Vector2 position = rigidbody2d.position;
    if (vertical)
    {
        position.y = position.y + speed * direction * Time.deltaTime;
    }
    else
    {
        position.x = position.x + speed * direction * Time.deltaTime;
    }
    rigidbody2d.MovePosition(position);
    
}
    void OnTriggerEnter2D(Collider2D other)
{
    PlayerController player =
    other.gameObject.GetComponent<PlayerController>();
    if (player != null)
    {
    player.ChangeHealth(-1);
    }
}
}
