using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColorChangingLineRenderer : MonoBehaviour
{

    PhysicsPointer laserInstance;
    Color prevColor;
    Color currColor;
    bool ColorIsChanging=false;

    List<Color> Colors = new List<Color>();

    public Color OldColor;
    public Color NewColor;
    int x = 0;
    int y = 0;
    // Start is called before the first frame update
    void Start()
    {

        laserInstance = PhysicsPointer.Instance;

    }
    
    
    // Update is called once per frame
    void Update()
    {
        currColor = GetComponent<Renderer>().material.GetColor("_TintColor"); // currentColor

            
            if(!GetComponent<SelectLineRenderer>().isSelected)
            {

            // idha fama changement mtaa couleur donc nkhabiweh fel stack mtaa changement 
            if (NewColor != OldColor)
            {
                UndoRedo.Instance.AddChangementToUndo(new Changement(gameObject.GetInstanceID(), NewColor, OldColor, ChangementType.COLOR_CHANGE_LINERENDERER));
            }

            Colors.Clear(); // Idha lineRenderer maadesh selected donc list nfarghohoa
            }

            if (currColor != prevColor && GetComponent<SelectLineRenderer>().isSelected) // if couleur mtaa taoua different aal couleur li kablou (li houa njibou fih mel LateUpdate)
            {    
                
                if(Colors.Count == 0) // Idha list fergha hot awel couleur howa ekher couleur kbal mayebda fel changement 
                Colors.Add(prevColor);
                
                if(!Colors.Contains(GetComponent<Renderer>().material.GetColor("_TintColor"))) 
                Colors.Add(GetComponent<Renderer>().material.GetColor("_TintColor"));// tant que fama changement yaani drag aal color picker donc aabi list b les couleurs



                SetOldColor();
                SetNewColor();

             
        }
    }

    private void LateUpdate()
    {
        prevColor = GetComponent<Renderer>().material.GetColor("_TintColor");
    }
 
    public void SetOldColor()
    {
        // une fois list(Colors) mtaa changement li feha les couleurs jdod 
        // awel couleur fel list houa l couleur initial mtaa changement
        OldColor = Colors[0];  
     //   Debug.Log("Old "+OldColor);
    }

    public void SetNewColor()
    {   
        // ekher couleur fel list houa l couleur jdid mtaa changement
        NewColor = Colors[Colors.Count-1];
     //   Debug.Log("New "+NewColor);
    }

}