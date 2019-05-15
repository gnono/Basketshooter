using UnityEngine;

using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour

{

    public Slider HealthBar;
    public float Health = 300;
    Image[] images;
    Color32[] Colors;

    private float currentHealth;
    [SerializeField] Text Lives;
    void Start()

    {

        currentHealth = Health;
       
    }



    public void TakeDamage(float damage)

    {

        currentHealth -= damage;

        HealthBar.value = currentHealth;
        GameObject fill = HealthBar.transform.GetChild(1).GetChild(0).gameObject;

        Image fillImage = fill.GetComponent<Image>();
        Color newColour = new Color(1f - (HealthBar.value / HealthBar.maxValue), HealthBar.value / HealthBar.maxValue, 0f);
        Debug.Log("Actual Health value" + HealthBar.value);
        fillImage.color = newColour;

        if (HealthBar.value >= 200)
        {
            Lives.text = "Lives: 3/3" ;
        }
        else if (HealthBar.value >= 100)
        {
            Lives.text = "Lives: 2/3";
        }
       else 
       { 
           Lives.text = "Lives: 1/3"; 
           
           }
            



    }
    public void GoodSlider(float value)
    {
        Health = value;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Reward")
        {
            TakeDamage(2);
        }
    }
}
