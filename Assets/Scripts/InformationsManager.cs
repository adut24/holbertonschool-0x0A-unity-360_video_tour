using UnityEngine;

/// <summary>
/// Represents the gestion of the informations button.
/// </summary>
public class InformationsManager : MonoBehaviour
{
    /// <summary>
    /// Show or hide the information bubble.
    /// </summary>
    /// <param name="informations">Information bubble</param>
    public void ManageInformations(GameObject information) => information.SetActive(!information.activeSelf);
}
