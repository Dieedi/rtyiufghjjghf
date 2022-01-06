using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    public Transform segmentPrefab;
    private List<Transform> segments;
    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            direction = Vector2.up;
            Debug.Log("Je vais vers le haut");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            direction = Vector2.left;
            Debug.Log("Je vais vers le Gauche");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
            Debug.Log("Je vais vers la Droite");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
            Debug.Log("Je vais vers le Bas");
        }
    }

    void FixedUpdate()
    {
        //this.transform.position = this.transform.position + direction;

        this.transform.position = new Vector3(
            this.transform.position.x + direction.x * 0.1f,
            this.transform.position.y + direction.y * 0.1f,
            0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("Je suis mort");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (other.gameObject.CompareTag("food"))
        {
            Debug.Log("Je te Miam !!!!");
            Destroy(other.gameObject);
            Transform segment = Instantiate(this.segmentPrefab);
            segment.position = segments[segments.Count - 1].position;
        }
            
    }
}
