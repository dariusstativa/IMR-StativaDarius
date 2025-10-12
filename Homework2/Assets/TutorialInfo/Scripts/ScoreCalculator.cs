using UnityEngine;
using TMPro;   

public class ScoreCalculator : MonoBehaviour
{
    public Transform player;        
    public TextMeshPro scoreText;  
    private int totalScore = 0;     

    private Renderer rend;          
    private Color baseColor;       

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            baseColor = rend.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            float distance = Vector3.Distance(player.position, transform.position);

            int points = Mathf.RoundToInt(distance * 10);

            totalScore += points;

            if (scoreText != null)
                scoreText.text = "Score: " + totalScore;

            if (rend != null)
            {
                rend.material.color = Color.red;
                Invoke("ResetColor", 0.3f); 
            }
        }
    }

    private void ResetColor()
    {
        if (rend != null)
            rend.material.color = baseColor;
    }
}
