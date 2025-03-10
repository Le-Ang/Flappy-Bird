using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minPosition;
    [SerializeField] private GameManager gameManager;
    public void Setup(GameManager gm)
    {
        gameManager = gm;
    }

    private void Awake()
    {
        gameObject.GetComponent<AudioSource>().mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetCanPlay())
        {
            return;
        }
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(transform.position.x<minPosition)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<AudioSource>().mute=false;
        gameManager.IncreaseScore();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
