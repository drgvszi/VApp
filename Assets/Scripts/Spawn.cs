using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System.Linq;

public class Spawn : MonoBehaviour
{
    public Transform parent1;
    public Transform parent2;
    Transform par;
    public Text qrText;
    string objectName;
    private Dictionary<string, bool> initializationStatus;
    public BoxCollider boxCollider1;
    public BoxCollider boxCollider2;
    Animator animator;
    void Start(){
        InitializeDictionary();
        boxCollider1.enabled = true;
        boxCollider2.enabled = true;
    }

    public void UpdateObjName(string newText)
    {
        objectName = newText;
    }
    void setParent()
    {
        if(objectName == "Object1")
        {
            par = parent1;
        }    
        if(objectName =="Object2")
        {
            par = parent2;
        }
    }
    public void SpawnObj()
    {

        var myGameObject = Resources.Load(objectName) as GameObject;
        setParent();
        initializationStatus.TryGetValue(objectName, out bool isInitialized);
        if (isInitialized)
        {
            Debug.Log($"{objectName} is already spawned.");
            return;
        }
        if (myGameObject != null)
        {
            if (par != null)
            {
                GameObject instantiatedObject = Instantiate(myGameObject, par);
                animator = instantiatedObject.AddComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("anim");
                initializationStatus[objectName] = true;           
                qrText.text = "Let's dance!";
 
            }
            else
            {
                Debug.LogError("Parent is not set.");

            }
        }
        else
        {
            Debug.LogError($"Failed to load {objectName}.");
        }
    }
    
    void InitializeDictionary()
    {
        initializationStatus = new Dictionary<string, bool>();
        //All resources
        string[] assetNames = Resources.LoadAll("").Select(asset => asset.name).ToArray();

        foreach (string assetName in assetNames)
        {
            if (!initializationStatus.ContainsKey(assetName))
            {
                initializationStatus.Add(assetName, false);
            }
        }
        //Debug
        foreach (var assetName in assetNames)
        {
            Debug.Log(assetName);
        }
    }
    
}

