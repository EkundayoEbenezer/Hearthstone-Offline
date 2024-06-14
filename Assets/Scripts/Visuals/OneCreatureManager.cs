using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OneCreatureManager : MonoBehaviour 
{
    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text HealthText;
    public Text AttackText;
	public Text ArmorText;
    [Header("Image References")]
	public GameObject ArmorIcon;
    public Image CreatureGraphicImage;
    public Image CreatureGlowImage;
    public bool hasTaunt;

    void Awake()
    {
        if (cardAsset != null)
        
            ReadCreatureFromAsset();
    }

     void Start()
    {
        if (cardAsset != null)
        {
            hasTaunt = cardAsset.hasTaunt;
            Debug.Log("CreatureManager for " + cardAsset.cardName + " has taunt: " + hasTaunt);
        }
        else
        {
            Debug.LogError("CardAsset is not initialized in OneCreatureManager");
        }
    }


    private bool canAttackNow = false;
    public bool CanAttackNow
    {
        get
        {
            return canAttackNow;
        }

        set
        {
            canAttackNow = value;

            CreatureGlowImage.enabled = value;
        }
    }

    public void ReadCreatureFromAsset()
    {
        // Change the card graphic sprite
        CreatureGraphicImage.sprite = cardAsset.CardImage;

        AttackText.text = cardAsset.Attack.ToString();
        HealthText.text = cardAsset.MaxHealth.ToString();
		ArmorText.text = cardAsset.Armor.ToString();
		if (cardAsset.Armor == 0) {
			ArmorIcon.SetActive (false);
		}

        if (PreviewManager != null)
        {
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }	

	public void TakeDamage(int amount, int healthAfter, int armorAfter, int attackAfter)
    {

        /*if (amount > 0)
        {*/
		if (armorAfter == 0) 
			ArmorIcon.SetActive (false);
            DamageEffect.CreateDamageEffect(transform.position, amount);
         //}

		HealthText.text = HealthText.ToString();
		AttackText.text = AttackText.ToString();
		ArmorText.text = armorAfter.ToString();

		
    }
    public void SwitchStats(int amount, int healthAfter, int armorAfter, int attackAfter)
    {

        /*if (amount > 0)
        {*/
		if (armorAfter == 0) 
			ArmorIcon.SetActive (false);
            DamageEffect.CreateDamageEffect(transform.position, amount);
         //}

		HealthText.text = attackAfter.ToString();
		AttackText.text = healthAfter.ToString();
		ArmorText.text = armorAfter.ToString();

		
    }
}
