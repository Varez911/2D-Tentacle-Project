//using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Movement movementScript;
    public int jumlahPoint = 3;
    public Transform lokasiTembakan;
    public GameObject pointCollide;
    public GameObject pointTujuan;
    public float speed = 1f;
    
    public LineRenderer Tentacles1;
    public LineRenderer Tentacles2;
    public LineRenderer Tentacles3;
    // public LineRenderer Tentacles4;
    public float maxDistance;
    //public bool Debug;

    private int points;
    private GameObject[] listInstate = new GameObject[10];
    private List<GameObject> listObjects = new List<GameObject>();

    private Vector2 endPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tentacles1.SetPosition(0, lokasiTembakan.position);
        Tentacles2.SetPosition(0, lokasiTembakan.position);
        Tentacles3.SetPosition(0, lokasiTembakan.position);
        
        if (points < 3)
        {
            Tentacles3.SetPosition(1, lokasiTembakan.position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            grab();
        }
        
        if (Input.GetMouseButtonDown(1))
        {                       
            shoot();
        }        
    }

    void shoot()
    {        
        RaycastHit2D hit = Physics2D.Raycast(lokasiTembakan.position, lokasiTembakan.right, maxDistance);
        if (hit.collider != null)
        {            
            listObjects.Add(Instantiate(pointCollide, (Vector3)hit.point, lokasiTembakan.rotation));
            
            switch(points % 3)
            {
                case 0:
                    Tentacles1.SetPosition(1, hit.point);
                    break;
                case 1:
                    Tentacles2.SetPosition(1, hit.point);
                    break;
                case 2:
                    Tentacles3.SetPosition(1, hit.point);
                    break;
            }

            if (points > 0)
            {
                Vector3 tujuan = Vector3.Lerp(listObjects[points].transform.position, listObjects[points - 1].transform.position, 0.5f);
                movementScript.mousePos = tujuan;
                
                movementScript.isMoving = true;
            }

            if (points > jumlahPoint - 1)
            {
                Destroy(listObjects[points - jumlahPoint]);
            }

            points += 1;
        }
    }

    void grab()
    {
        endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 startPos = lokasiTembakan.position;
        Vector2 ending = Vector2.Lerp(startPos, endPos, speed/5 * Time.deltaTime);
        //Tentacles4.SetPosition(1, ending);
    }
}