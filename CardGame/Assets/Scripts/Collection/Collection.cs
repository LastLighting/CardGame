using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour {

    public Card card;
    public float startTransformX;
    public float startTransformY;
    public float transformX;
    public float transformY;

    void Start () {
        Vector3 position = transform.position;
        position.y = position.y + startTransformY;
        position.x = position.x - startTransformX;
        position.z = 0;
        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                Card newCard = Instantiate(card, position, card.transform.rotation) as Card;
                newCard.changeSprite(Random.Range(0,3));
                position.x = position.x + transformX;
            }
            position.x = transform.position.x - startTransformX;
            position.y = position.y - transformY;
        }
        /*StartCoroutine(GetText());*/

    }

    /*IEnumerator GetText()
    {
       
    }*/
}
