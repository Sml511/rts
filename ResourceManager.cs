using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    public static ResourceManager Instance {get; private set;}

   

    public event EventHandler OnResourceAmountChanged;

    [SerializeField] private List<ResourceAmount> startResourceAmountList;



    private Dictionary<ResourceTypeSO,int> resourceAmountDictionary;





    private void Awake()
    {

        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO,int>();


        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);


        foreach(ResourceTypeSO resourceType in resourceTypeList.list)
        {


            resourceAmountDictionary[resourceType] = 0;


        }
        foreach(ResourceAmount resourceAmount in startResourceAmountList)
        {

            AddResource(resourceAmount.resourceType,resourceAmount.amount);


        }

        


    }



    private void Update()
    {


        if(Input.GetKeyDown(KeyCode.T))
        {


            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0],2);
            TestLogResourceAmountDictionary();

        }




    }





    private void TestLogResourceAmountDictionary()
    {

        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {


            Debug.Log(resourceType.nameString + ":" + resourceAmountDictionary[resourceType]);



        }





    }

    public void AddResource(ResourceTypeSO resourceType,int amount)
    {


        resourceAmountDictionary[resourceType] += amount;


        OnResourceAmountChanged?.Invoke(this,EventArgs.Empty);


       



        

    }


    public int GetResourceAmount(ResourceTypeSO resourceType)
    {



        return resourceAmountDictionary[resourceType];



    }


    public bool CanAfford(ResourceAmount[] resourceAmountArray)
    {

        foreach(ResourceAmount resourceAmount in resourceAmountArray)
        {

            if(GetResourceAmount(resourceAmount.resourceType) >= resourceAmount.amount)
            {




            }else
            {

                return false;


            }



        }

        return true;

    }

    public void SpendResources(ResourceAmount[] resourceAmountArray)
    {


        foreach(ResourceAmount resourceAmount in resourceAmountArray)
        {


            resourceAmountDictionary[resourceAmount.resourceType] -= resourceAmount.amount;
        }




    }



}
