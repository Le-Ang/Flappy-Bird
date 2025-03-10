using UnityEngine;
using System.Collections;
using TMPro;

public class Controls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float flyForce;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float maxYPosition;
    [SerializeField] private float flyAngle;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;

    public void Awake()
    {
        if (gameManager.GetIsPlay())
        {
            body.gravityScale = 0;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameManager.GetIsPlay())
        {
            audioManager.AudioFlap();
            body.gravityScale = 3;
            gameManager.SetIsPlay(true);
            body.velocity = Vector2.zero;
            body.AddForce(Vector2.up * flyForce);
        }else if (Input.GetMouseButtonDown(0)&&gameManager.GetCanPlay())
        {
            audioManager.AudioFlap();
            body.velocity = Vector2.zero;
            body.AddForce(Vector2.up * flyForce);
        }
    }

    void FixedUpdate()
    {
        if(body.velocity.y > maxVelocity)
        {
            body.velocity = new Vector2(0, maxVelocity);
        }else if(body.velocity.y < -maxVelocity)
        {
            body.velocity = new Vector2(0, -maxVelocity);
        }
        if(transform.position.y > maxYPosition)
        {
            transform.position = new Vector3(0, maxYPosition,0);
        }
        if (body.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0,0,flyAngle);
        }else if(body.velocity.y < 0)
        {
            transform.eulerAngles = new Vector3(0,0,-flyAngle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.SetCanPlay(false);
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        gameManager.SetIsPlay(false);
    }
}
