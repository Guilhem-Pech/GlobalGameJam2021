using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private Gradient gradient;
    public float health;

    private void Start() {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void Damage(int amount)
    {
        health -= amount;
    }

    protected virtual void Update() {
        healthBar.value = health;
        healthBar.fillRect.GetComponent<Image>().color = gradient.Evaluate(health / maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

}
