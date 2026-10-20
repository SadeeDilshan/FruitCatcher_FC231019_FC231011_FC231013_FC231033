using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;
    public float xLimit = 8f;



    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
        float clamedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        transform.position = new Vector3(clamedX, transform.position.y,0f);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Fruit")) {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            GameManager.instance.LoseLife();
            Destroy(other.gameObject);
        }
    }


}
