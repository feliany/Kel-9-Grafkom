using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    static public KeyHolder Instance;
    public Text FinalScore;
    public Text myScore;
    public int score = 0;

    private List<Key.KeyType> keyList;

    private void Awake() {
        keyList = new List<Key.KeyType>();
        Instance = this;
    }

    public List<Key.KeyType> GetKeyList() {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType) {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType) {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Key key = collision.GetComponent<Key>();
        if (key != null) {
            AddKey(key.GetKeyType());
            key.gameObject.SetActive(false);
        } 

        KeyDoor keyDoor = collision.GetComponent<KeyDoor>();
        if (keyDoor != null) {
            if (ContainsKey(keyDoor.GetKeyType())) {
                //Lagi pegang kunci terkait
                score = score + 1;
                RemoveKey(keyDoor.GetKeyType());
                MainGame.Instance.Randomize();
                myScore.text = "Score : " + score;
            }
        }
    }
    public void showScore()
    {
        FinalScore.text = "Final Score : " + score;
    }
}
