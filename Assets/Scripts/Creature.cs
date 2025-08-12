
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Creature : MonoBehaviour
{
    public CardTemplate template;
    public int ownerPlayerId;
    public Block block;

    [SerializeField] private int currentHealth;

    public int Health
    {
        get { return currentHealth; }
        set { currentHealth = value; healthText.text = value.ToString(); Debug.Log("Set health to " + value); }
    }
    private int currentAttack;

    public int Attack
    {
        get { return currentAttack; }
        set { currentAttack = value; attackText.text = value.ToString(); Debug.Log("Set attack to " + value); }
    }

    private int currentCost;
    public int Cost
    {
        get { return currentCost; }
        set { currentCost = value; }
    }
    public SpriteRenderer Image;

    [SerializeField]
    private TextMeshPro healthText,
                            attackText;

    public int ActionPointRefill = 1;
    public int ActionPoint
    {
        get => actionPoint; set
        {
            actionPoint = value;
            GetComponent<CreatureSelect>().Select(actionPoint <= 0 ? SelectState.Inactive : SelectState.Default);
        }
    }

    private int actionPoint = 0;

    public UnityEvent TurnStartEffect;
    public PreBattleEvent PreBattleEffect = new PreBattleEvent();
    public PostBattleEvent PostBattleEffect = new PostBattleEvent();
    public bool interactable = true;
    public UnityEvent InteractEffect;
    public int ElementCount = 0;

    public bool isPlayer = false;
    public void Init(CardTemplate template, Block block, int Id)
    {
        ActionPointManager.Instance.ActionPointRefill.AddListener(RefillActionPoint);

        this.template = template;
        this.block = block;
        block.EnterBlock(this);
        this.ownerPlayerId = Id;
        SetTransform();
        if (this.template != null) InitStats();
    }

    void SetTransform()
    {
        transform.position = block.transform.position;
        Vector3 scale = transform.localScale;
        scale.y *= (ownerPlayerId == 0) ? 1 : -1;
        scale.x *= (ownerPlayerId == 0) ? 1 : -1;
        transform.localScale = scale;

    }
    void InitStats()
    {
        Attack = template.attack;
        Health = template.health;
        ActionPointRefill = ActionPoint = template.actionPoint;
        ActionPoint = 1;
        Image.sprite = template.sprite;
        foreach (Element element in template.element)
        {
            AddElement(element);
        }
    }

    //check perform on the initiator action
    public bool Interactable(Creature creature)
    {
        if (creature.ownerPlayerId != ownerPlayerId)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void MoveToBlock(Block target)
    {
        ActionPoint -= 1;
        gameObject.transform.position = target.transform.position;
        block = target;
    }

    public bool ReadyToAction()
    {
        if (CardHouse.PhaseManager.Instance.CurrentPlayer == ownerPlayerId)
        {
            if (ActionPoint > 0)
            {
                return true;
            }
        }
        return false;
    }

    void OnDestroy()
    {
        ActionPointManager.Instance.ActionPointRefill.RemoveListener(RefillActionPoint);

        block.LeaveBlock();
    }

    void RefillActionPoint()
    {
        ActionPoint = ActionPointRefill;
        TurnStartEffect?.Invoke();
    }

    public void AddElement(Element element)
    {
        if (ElementToScript(element))
        {
            GetComponent<ElementBarHandler>().AddElement(element);
            ElementCount++;
        }

        
    }

    public bool CanAddElement(Element element)
    {
        return CheckElementNotExist(element) && ElementCount <= 3 && !isPlayer;
    }



    public bool ElementToScript(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                if (GetComponent<FireEffect>() == null)
                {
                    gameObject.AddComponent<FireEffect>();
                    return true;
                }
                return false;
            case Element.Water:
                if (GetComponent<WaterEffect>() == null)
                {
                    gameObject.AddComponent<WaterEffect>();
                    return true;
                }
                return false;
            case Element.Earth:
                if (GetComponent<EarthEffect>() == null)
                {
                    gameObject.AddComponent<EarthEffect>();
                    return true;
                }
                return false;
            case Element.Lightning:
                if (GetComponent<LightningEffect>() == null)
                {
                    gameObject.AddComponent<LightningEffect>();
                    return true;
                }
                return false;
            case Element.Ice:
                if (GetComponent<IceEffect>() == null)
                {
                    gameObject.AddComponent<IceEffect>();
                    return true;
                }
                return false;
            case Element.Grass:
                if (GetComponent<GrassEffect>() == null)
                {
                    gameObject.AddComponent<GrassEffect>();
                    return true;
                }
                return false;
        }
        return false;
    }   
    bool CheckElementNotExist(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                if (GetComponent<FireEffect>() == null)
                {
                    return true;
                }
                return false;
            case Element.Water:
                if (GetComponent<WaterEffect>() == null)
                {
                    return true;
                }
                return false;
            case Element.Earth:
                if (GetComponent<EarthEffect>() == null)
                {
                    return true;
                }
                return false;
            case Element.Lightning:
                if (GetComponent<LightningEffect>() == null)
                {
                    return true;
                }
                return false;
            case Element.Ice:
                if (GetComponent<IceEffect>() == null)
                {
                    return true;
                }
                return false;
            case Element.Grass:
                if (GetComponent<GrassEffect>() == null)
                {
                    return true;
                }
                return false;
        }
        return false;
    }   


}
