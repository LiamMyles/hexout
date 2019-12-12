using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LifesManager lifeManger;
    public GameObject smoke;

    void Awake()
    {
        lifeManger = GameObject.FindObjectOfType<LifesManager>();
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);

        GameObject smokePuff = Instantiate(smoke, collider.transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = Color.red;
        Destroy(smokePuff, 1f);

        StartCoroutine(WaitOne());
    }

    IEnumerator WaitOne()
    {
        yield return new WaitForSeconds(1);
        lifeManger.LoseLife();
        lifeManger.RespawnBall();
    }
}
