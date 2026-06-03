using UnityEngine;

public class CUBITOS : MonoBehaviour

{
    [SerializeField] private GameObject cubito;
    [SerializeField] private GameObject[] cubitos;


    [SerializeField] private GameObject cubitoImportante;
    [SerializeField] private GameObject [] marcadoresRelevantes;

    public void Start()
    {
        CrearCubitos();
    }
    public void CrearCubitos()
    {
        for (int i = 0; i < cubitos.Length; i++)
        {
            GameObject cubitoInstanciado = Instantiate(cubito, transform.position, Quaternion.identity);
            cubitoInstanciado.transform.SetParent(cubitos[i].transform);
            cubitoInstanciado.transform.localPosition = Vector3.zero;
            cubitoInstanciado.transform.localRotation = Quaternion.identity;
            cubitoInstanciado.name = cubitoInstanciado.transform.parent.name;
        }

        for (int i = 0; i < marcadoresRelevantes.Length; i++)
        {
            GameObject cubitoInstanciado = Instantiate(cubitoImportante, transform.position, Quaternion.identity);
            cubitoInstanciado.transform.SetParent(marcadoresRelevantes[i].transform);
            cubitoInstanciado.transform.localPosition = Vector3.zero;
            cubitoInstanciado.transform.localRotation = Quaternion.identity;
            cubitoInstanciado.name = cubitoInstanciado.transform.parent.name;

        }
    }



}