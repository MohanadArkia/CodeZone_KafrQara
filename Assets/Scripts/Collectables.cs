using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    int score = 0;
    public ParticleSystem effectInspector;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            scoreText.text = score.ToString();

            Vector3 coinPosition = other.transform.position;

            ParticleSystem effect = Instantiate(effectInspector, coinPosition, Quaternion.identity);

            Destroy(effect.gameObject, effect.main.duration);


            Destroy(other.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}