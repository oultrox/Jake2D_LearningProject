using UnityEngine;

//Class made to collect the coins 
public class Collectable : MonoBehaviour {

    private bool isCollected = false;

    //----Metodos API------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }

    //----Metodos custom-----
    public void Show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void Collect()
    {
        isCollected = true;
        Hide();
        GameManager.Instance.CollectedCoin();
    }

    
}
