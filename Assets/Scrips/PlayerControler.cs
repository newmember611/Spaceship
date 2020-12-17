using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefabs;
    public KeyCode fireKey;
    private Rigidbody2D rigidBody;
    public static float speed = 5f;
    public float speedBullet;
    private float maxXBounds, maxYBounds, minXBounds, minYBounds;
    private Vector3 bounds, scalePlayer, coliderPlayer;
    private Animator move;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        scalePlayer = this.gameObject.GetComponent<Transform>().transform.localScale;
        coliderPlayer = this.gameObject.GetComponent<BoxCollider2D>().size;
        
        maxXBounds = bounds.x - (scalePlayer.x * (coliderPlayer.x/2));
        minXBounds = -(bounds.x) + (scalePlayer.x * (coliderPlayer.x / 2));
        minYBounds = -(bounds.y) + (scalePlayer.x * (coliderPlayer.x / 2));
        maxYBounds = 0 - (scalePlayer.x * (coliderPlayer.x / 2));
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        move = GetComponent<Animator>();

        
    }
    void Update()
    {
        if (Input.GetKey("left"))
        {
            move.SetBool("MoveLeft", true);
            move.SetBool("MoveRight", false);
        }
        else if (Input.GetKey("right"))
        {
            move.SetBool("MoveLeft", false);
            move.SetBool("MoveRight", true);
        }
        else
        {
            move.SetBool("MoveLeft", false);
            move.SetBool("MoveRight", false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, minXBounds, maxXBounds);
        viewPos.y = Mathf.Clamp(viewPos.y, minYBounds, maxYBounds);
        transform.position = viewPos;
    }

    void FixedUpdate()
    {
        _PlayerMove();

    }

    void _PlayerMove()
    {

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        this.gameObject.transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    IEnumerator shoot()
    {

        //Instantiate your projectile
        Vector3 Temp = transform.position;
        Temp.y += 0.3f;
        if (Input.GetKey(fireKey))
        {

            GameObject bullet = (GameObject)Instantiate(bulletPrefabs, Temp, Quaternion.identity);
            bullet.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * speedBullet;
            yield return new WaitForSeconds(0.25f);
            Destroy(bullet, 2);

        }
        //wait for some time

        yield return new WaitForSeconds(0f);
        StartCoroutine(shoot());

    }


}
