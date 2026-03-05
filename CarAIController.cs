using UnityEngine;
using TMPro; // This handles your text boxes

public class CarAIController : MonoBehaviour
{
    [Header("Car Settings")]
    public MeshRenderer carBody; // Drag 'SportCar_1' here

    [Header("UI Settings")]
    public TMP_InputField themeInput;
    public TMP_Text feedbackText;

    public void ApplyAISuggestion()
    {
        string input = themeInput.text.ToLower();

        // Demonstrating 3-5 AI options as required by the brief
        if (input.Contains("sporty"))
        {
            UpdateCar(Color.red, "AI SUGGESTION: Racing Red & Performance Tuned.");
        }
        else if (input.Contains("luxury"))
        {
            UpdateCar(new Color(0.1f, 0.1f, 0.1f), "AI SUGGESTION: Obsidian Black & Chrome Finish.");
        }
        else if (input.Contains("modern"))
        {
            UpdateCar(Color.white, "AI SUGGESTION: Pearl White & Minimalist Design.");
        }
        else
        {
            feedbackText.text = "Try typing 'Sporty', 'Luxury', or 'Modern'...";
        }
    }

    void UpdateCar(Color color, string message)
    {
        // Updates the car color in real-time
        carBody.material.SetColor("_BaseColor", color);
        feedbackText.text = message;
        Debug.Log(message);
    }
}