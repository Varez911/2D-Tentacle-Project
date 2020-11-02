using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject FirePoint1;
    [SerializeField]
    public Rigidbody2D body;
    [Range(1, 5)]
    public int multipler;


    
    private float speed;
    public Vector3 mousePos;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lookAtMouse();
        /*
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
        */
        
    }

    void FixedUpdate()
    {
        speed = Vector2.Distance(transform.position, mousePos);
        Move(mousePos);
    }

    void lookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = direction;
    }

    public void Move(Vector3 direction)
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime * multipler);
        }
        if (transform.position == direction)
        {
            isMoving = false;
        }
        
    }    
    
}
