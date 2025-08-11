
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
    public int ActionPoint { get => actionPoint; set {
            actionPoint = value;
            Debug.Log(actionPoint);
            GetComponent<CreatureSelect>().Select(actionPoint <= 0 ? SelectState.Inactive : SelectState.Default); } }

    private int actionPoint = 0;

    public UnityEvent TurnStartEffect;
    public PreBattleEvent PreBattleEffect = new PreBattleEvent();
    public PostBattleEvent PostBattleEffect = new PostBattleEvent();
    public bool interactable = true;
    public UnityEvent InteractEffect;

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
        Health  = template.health;
        ActionPointRefill = ActionPoint = template.actionPoint;
        ActionPoint = 1;
        Image.sprite = template.sprite;
        if(CardTemplate.ElementToScript(template.element, this)) GetComponent<ElementBarHandler>().AddElement(template.element);
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
}
