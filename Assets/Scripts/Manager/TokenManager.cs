using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{

    public static TokenManager Instance;
    void Awake()
    {
        Instance = this;
    }
    public GameObject tokenPrefab;
    public Transform parentTransform;
    public List<Token> tokens;
    public void Init(int[] elements)
    {
        for(int i = 0; i < elements.Length; i++ )
        {
            for (int j = 0; j < elements[i]; j++)
            {
                Element element = (Element)i;
                GameObject instance = Instantiate(tokenPrefab, parentTransform);
                Token token = instance.GetComponent<Token>();
                token.SetElement(element);
                tokens.Add(token);
            }
        }
    }

    public void Clear()
    {
        foreach(Token token in tokens){
            Destroy(token.gameObject);
        }
        tokens.Clear();
    }
}
