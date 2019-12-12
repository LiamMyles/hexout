using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;
    public bool bomb;

    private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private SpriteRenderer render;
    private bool isBreakable;

    public static int breakableCount = 0;

	// Use this for initialization
    void Awake()
    {
        isBreakable = (this.tag == "Breakable");
        //Keeps track of breakable bricks. 
        if (isBreakable)
        {
            breakableCount++;
        }
    }

	void Start ()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        render = GetComponent<SpriteRenderer>();
        maxHits = hitSprites.Length + 1;
	}

    void OnCollisionEnter2D (Collision2D hit)
    {
        if(isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
        //print(breakableCount);
    }

    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            if (bomb)
            {
                this.gameObject.GetComponent<BrickBomb>().Trigger();
            }
            HandlePartical();
            breakableCount--;
            levelManager.BrickDestoyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void HandlePartical()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, 1f);
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if( hitSprites[spriteIndex] != null)
        {
            render.sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    public void InstantDestory()
    {
        HandlePartical();
        breakableCount--;
        levelManager.BrickDestoyed();
        Destroy(gameObject);
    }
}
