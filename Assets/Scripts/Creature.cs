
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    public CardTemplate template;
    public int ownerPlayerId;
    public Block block;

    private int DefaultHealth;
    private int currentHealth;

    public int Health
    {
        get { return currentHealth; }
        set { currentHealth = value; healthText.text = value.ToString(); Debug.Log("Set health to " + value); }
    }
    private int currentAttack;
    private int DefaultAttack;

    public int Attack
    {
        get { return currentAttack; }
        set { currentAttack = value; attackText.text = value.ToString(); Debug.Log("Set attack to " + value); }
    }
    private int DefaultCost;

    private int currentCost;
    public int Cost
    {
        get { return currentCost; }
        set { currentCost = value; costText.text = value.ToString(); }
    }
    [SerializeField]
    private TextMeshPro healthText,
                            costText,
                            attackText;

    private int ActionPointRefill = 0;
    public int actionPoint = 0;
    public UnityEvent TurnStartEffect;
    public PreBattleEvent PreBattleEffect = new PreBattleEvent();
    public PostBattleEvent PostBattleEffect = new PostBattleEvent();
    public SpriteRenderer elementSymbol;
    public bool interactable = true;

    public UnityEvent InteractEffect;
    public void Start()
    {
        ActionPointManager.Instance.ActionPointRefill.AddListener(RefillActionPoint);
    }


    public void Init(CardTemplate template, Block block, int Id)
    {
        this.template = template;
        this.block = block;
        block.EnterBlock(this);
        this.ownerPlayerId = Id;
        SetTransform();
        InitStats();
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
        Attack = DefaultAttack = template.attack;
        Health = DefaultHealth = template.health;
        Cost = DefaultCost = template.moveCost;
        ActionPointRefill = actionPoint = template.actionPoint;
        actionPoint = 0;

        if (elementSymbol != null) elementSymbol.color = gameObject.GetComponent<ColorFinder>().Find(template.element);

        CardTemplate.ElementToScript(template.element, this);
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
        actionPoint -= 1;
        gameObject.transform.position = target.transform.position;
        block = target;
    }

    public bool ReadyToAction()
    {
        if (CardHouse.PhaseManager.Instance.CurrentPlayer == ownerPlayerId)
        {
            if (actionPoint > 0)
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
        actionPoint = ActionPointRefill;
        TurnStartEffect?.Invoke();
    }
}
