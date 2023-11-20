using UnityEngine;
using Vuforia;

public class QRScanner : MonoBehaviour
{

    [SerializeField] private Spawn sp;
    BarcodeBehaviour mBarcodeBehaviour;
    string qrText;
    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            qrText = mBarcodeBehaviour.InstanceData.Text;
            if (sp != null)
            {   
                sp.UpdateObjName(qrText);
            }
            else
            {
                Debug.LogError("sp is not assigned.");
            }
        }
        else
        {
            qrText = "";
        }
    }
}