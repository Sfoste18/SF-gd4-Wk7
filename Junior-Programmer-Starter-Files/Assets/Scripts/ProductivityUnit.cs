using UnityEngine;

public class ProductivityUnit : Unit
{
    //New variables
    //private ResourcePile m_CurrentPile = null;
    ResourcePile currentPile = null;
    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
      
        //if currently we do not have a resource assigned
        if (currentPile == null)
        {
            //trying to find a resource
            ResourcePile pile = m_Target as ResourcePile;

            //if we do find a resource, we are multiplying the production speed
            if (pile != null)
            {
                //setting the current resource to the resource we found before
                currentPile = pile;

                //adding a multiplier on the production speed
                currentPile.ProductionSpeed *= productivityMultiplier;
            }

        }
    }



    void resetProductivity()
    {
        //resets the productivity speed when the unit leaves the resource
        if (currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        resetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        resetProductivity();
        base.GoTo(position);
    }

}
