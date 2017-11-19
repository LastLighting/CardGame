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
        StartCoroutine(GetText());

    }

    IEnumerator GetText()
    {
        WWWForm form = new WWWForm();
        string jsonStr = "{\"objects\":[{\"id\":1,\"title\":\"Book\",\"position_x\":0,\"position_y\":0,\"position_z\":0,\"rotation_x\":0,\"rotation_y\":0,\"rotation_z\":0,\"created\":\"2016-09-21T14:22:22.817Z\"},{\"id\":2,\"title\":\"Apple\",\"position_x\":0,\"position_y\":0,\"position_z\":0,\"rotation_x\":0,\"rotation_y\":0,\"rotation_z\":0,\"created\":\"2016-09-21T14:22:52.368Z\"}]}";
        form.AddField("field", "pisos");
        form.AddField("guid", "22345200-abe8-4f60-90c8-0d43c5f6c0f6");
        form.AddField("card", "alien");
        var formData = System.Text.Encoding.UTF8.GetBytes(jsonStr);
        UnityWebRequest www = UnityWebRequest.Post("https://cardgamejavaserver.herokuapp.com/user/registration", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
       
    }

}
