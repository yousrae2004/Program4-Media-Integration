using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Needed for the Input Field

public class MainMenuController : MonoBehaviour
{
    public GameObject namePanel;      // Slot for the Panel
    public TMP_InputField nameInput;  // Slot for the Input Field

    // 1. This runs when you click the main "Play" button
    public void OpenNamePrompt()
    {
        namePanel.SetActive(true); // Show the name entry screen
    }

    // 2. This runs when you click "Start Game" inside the panel
    public void StartGameWithName()
    {
        // Save the name to our "Backpack" script
        if (nameInput.text.Length > 0)
        {
            GameGlobals.playerName = nameInput.text;
        }

        // Load the house scene
        SceneManager.LoadScene("HouseInterior");
    }
}
/*public class MainMenuController : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("HouseInterior");
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("HouseInterior");
    }
} */
