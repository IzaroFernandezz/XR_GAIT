using Meta.XR.MRUtilityKit;
using UnityEngine;

public class FloorAlineator : MonoBehaviour
{
    public float offsetY = 0.0f; // Offset opcional para ajustar la altura del objeto

    void Start()
    {
               // Suscríbete al evento de carga de escena para asegurarte de que el suelo esté detectado
        //OnSceneLoaded();
    }

    public void OnSceneLoaded()
    {
        // Obtiene la habitación actual cargada
        var room = MRUK.Instance.GetCurrentRoom();

        // Busca específicamente el ancla del suelo (FLOOR)
        var floorAnchor = room.GetFloorAnchor();

        if (floorAnchor != null)
        {
            Vector3 positionAux = new Vector3(floorAnchor.transform.position.x, floorAnchor.transform.position.y + offsetY, floorAnchor.transform.position.z);
            // Posiciona tu objeto en el centro del suelo detectado
            transform.position = positionAux;
            // O usa la altura (Y) para alinear múltiples objetos
            float floorHeight = floorAnchor.transform.position.y;
        }
    }
}