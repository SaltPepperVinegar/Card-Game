using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class SpellCard : Card
{
    public GameObject spellPrefab;
    private GameObject spellInstance;
    public List<Block> blocks = new List<Block>();

    void Start()
    {
        elementalCosts = template.cost;
    }

    public void CastSpell()
    {
        spellPrefab.GetComponent<SpellEffect>().CastSpell(blocks, OwnerPlayerId);
    }

    public override bool CheckDropable(Block block)
    {
        return true;
    }

    public void StartDrag()
    {
        blocks.Clear();
        Debug.Log("start drag");
        spellInstance = Instantiate(spellPrefab, gameObject.transform);
        spellInstance.GetComponent<Spell>().Init(this);
        spellInstance.transform.localPosition = Vector3.zero;

    }

    public void EndDrag()
    {
        Debug.Log("end drag");
        Destroy(spellInstance);
        
    }
}

