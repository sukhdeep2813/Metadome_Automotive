using UnityEngine;
using TMPro;

public class CarAIController : MonoBehaviour
{
    [Header("Car Settings")]
    public MeshRenderer carBody; // Link SportCar_1 here

    [Header("UI Settings")]
    public TMP_InputField themeInput; // Link InputField (TMP)
    public TMP_Text feedbackText;     // Link Text (TMP)

    public void ApplyAISuggestion()
    {
        // Trim removes accidental spaces that break input detection
        string input = themeInput.text.ToLower().Trim();

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
            UpdateCar(Color.blue, "AI SUGGESTION: Electric Blue & Tech-Focused Interior.");
        }
        else if (input.Contains("eco") || input.Contains("green"))
        {
            UpdateCar(Color.green, "AI SUGGESTION: Forest Green & Sustainable Materials.");
        }
        else
        {
            feedbackText.text = "Try 'sporty', 'luxury', 'modern', or 'eco'.";
        }
    }

    void UpdateCar(Color color, string message)
    {
        if (carBody == null) return;

        Material[] currentMaterials = carBody.materials;

        // Slot 2 is Body1 in your car model
        if (currentMaterials.Length > 2)
        {
            // Set the color and force the shader to use it as a tint
            currentMaterials[2].SetColor("_BaseColor", color);
            currentMaterials[2].SetColor("_Color", color);

            // This ensures the color isn't hidden by the texture
            currentMaterials[2].globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;

            carBody.materials = currentMaterials;
        }

        feedbackText.text = message;
        Debug.Log(message);
    }
}