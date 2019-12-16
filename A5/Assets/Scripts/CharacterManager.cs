using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterManager : MonoBehaviour
{
    public List<GameObject> characterList;
    public ParticleSystem enemyParticle;
    public ParticleSystem clickParticle;
    bool foundCharacter = false;

    // Start is called before the first frame update
    void Start()
    {
        characterList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                GameObject characterGameObject = hit.collider.gameObject;
                if (characterGameObject.CompareTag("Player"))
                {
                    foundCharacter = false;
                    foreach (var item in characterList)
                    {
                        if (item == characterGameObject)
                        {
                            characterList.Remove(characterGameObject);
                            foundCharacter = true;
                            break;
                        }
                    }
                    if(foundCharacter == false)
                    {
                        characterList.Add(characterGameObject);
                    }
                    
                }

                foreach (var item in characterList)
                {
                    CharacterMove move = item.GetComponent<CharacterMove>();
                    move.Walk(hit);
                }
            }
        }

        


    }
}
