using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DHMarchalController : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Animator animator;
    private Rigidbody2D m_rb;
    private Vector2 m_movement;
    public  DHInventory inventory;
    public DHHUD Hud;
    private IInventoryItem m_item_to_pickup = null;
    private bool m_lock_pickup = false;
    public int nbvie = 3; // on a max 3 vie et après ça descend

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_movement = new Vector2(0, 0);
        inventory.ItemUsed += Inventory_ItemUsed;
        m_item_to_pickup = null;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventsArgs e)
    {
        IInventoryItem item = e.Item;

        // Do something with the item
        Debug.Log("Marchal Use Item : " + item.Name);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            StaticCode.stopAllMusic();
        }

            if (m_item_to_pickup != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(m_item_to_pickup);
            Hud.CloseMessagePanel();
            m_item_to_pickup = null;
        }

        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");
        if (m_movement.x != 0 || m_movement.y != 0)
            GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 0);
        else
            GetComponents<FMODUnity.StudioEventEmitter>()[1].SetParameter("Silence", 1);
        animator.SetFloat("speed", m_movement.sqrMagnitude);
        animator.SetFloat("horizontal", m_movement.x);
        animator.SetFloat("vertical", m_movement.y);
        //Debug.Log(m_movement.sqrMagnitude);

        if(nbvie == 2)
        {
            transform.Find("jauge").gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        } else if(nbvie == 1)
        {
            transform.Find("jauge").gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(nbvie == 0)
        {
            //Debug.Log("On est mort !");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            GameObject[] inGameUIObjs = GameObject.FindGameObjectsWithTag("InGameUI");
            if (inGameUIObjs.Length >= 0)
            {
                foreach (GameObject obj in inGameUIObjs)
                {
                    obj.SetActive(false);
                }
            }

            GameObject gameOver = GameObject.FindGameObjectWithTag("GameOver");
            if (gameOver)
            {
                for (int i = 0; i < gameOver.transform.childCount; ++i)
                {
                    gameOver.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        } else
        {
            transform.Find("jauge").gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + m_movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
        if (item != null)
        {
            if (m_lock_pickup)
                return;

            m_item_to_pickup = item;

            Hud.OpenMessagePanel("- F pour ramasser -");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
        if (item != null)
        {
            Hud.CloseMessagePanel();
            m_item_to_pickup = null;
        }
    }
}
