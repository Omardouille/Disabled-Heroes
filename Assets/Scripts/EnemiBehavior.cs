using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiBehavior : MonoBehaviour
{
    enum States { Patrolling, Attak };
    States currentState = States.Patrolling;
    float currentDirection = (float)0;
    GameObject playerFollow = null;
    public Animator animator;


    public Rigidbody2D rb;

    public float speed = 2f;
    // Pour l'instant c'est instant death et l'attaque c'est foncé sur l'individu
    // On pourra améliorer l'état

    // Start is called before the first frame update
    void Start()
    {
        currentState = States.Patrolling;
        currentDirection = (float)0;
        rb = GetComponent<Rigidbody2D>();
        playerFollow = null;
        GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("Silence", 0);
        // On lui donne un pitch aléatoire comme ça ça fait un peu que chaque ennemi à son son
        GetComponents<FMODUnity.StudioEventEmitter>()[0].SetParameter("pitch", Random.Range(0f, 1.0f));
        GetComponents<FMODUnity.StudioEventEmitter>()[0].Play();

    }

    // Update is called once per frame
    void Update()
    {
        // Il va dans une direction aléatoire  et quand il touche un mur il va ailleurs
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (currentState == States.Patrolling)
        {
            patrol();
        }
        else 
        {
            attak();
        }

    }

    private void patrol()
    {
        Vector3 oldPosition = transform.position;
        this.transform.Rotate(0, 0, currentDirection);
        this.transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        this.transform.Rotate(0, 0, -currentDirection);

        Vector3 movement = transform.position - oldPosition;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", 1);

        rb.MovePosition(transform.position);
    }

    private void attak()
    {
        // On pourra changer l'animation + so
        if(playerFollow == null)
            currentState = States.Patrolling;

        Vector3 dir = -(this.transform.position - playerFollow.transform.position).normalized * speed * Time.fixedDeltaTime;
        
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", 1);

        rb.MovePosition(transform.position+dir);

    }

    public void isNear(Collider2D collider)
    {
        if(currentState == States.Patrolling && collider.gameObject.tag == "Player")
        {
            currentState = States.Attak;
            playerFollow = collider.gameObject;
        }

    }

    public void isNotNear(Collider2D collider)
    {
        if (currentState == States.Attak && collider.gameObject.tag == "Player")
        {
            currentState = States.Patrolling;
            playerFollow = null;
        }
    }

    public void isTouched()
    {
        Debug.Log("Ennemi est mort");
        Destroy(gameObject);
    }

    private void changeDirection()
    {
        currentDirection += Random.Range(0.0f, 90.0f) + 180f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Le joueur est dead");
        }
        changeDirection(); 
    }

    public void OnDestroy()
    {
        GetComponents<FMODUnity.StudioEventEmitter>()[0].Stop();
    }
}
