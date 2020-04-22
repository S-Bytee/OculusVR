using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FreeDraw
{
    // Helper methods used to set drawing settings
    public class DrawingSettings : MonoBehaviour
    {
        public static bool isCursorOverUI = false;
        public float Transparency = 1f;
        public GameObject newQuad; 
        public GameObject currNewQuad;
        public GameObject newTriangle;
        public GameObject currNewTriangle;
        public bool onfollow = false;
        public bool onfollowT = false;
        public Color c  = Color.black;
        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width


        public void Update()
        {
            releaseQuad();
            releaseTriangle();
        }

        public void SetMarkerColour(Color new_color)
        {
            Drawable.Pen_Colour = new_color;
        }
        // new_width is radius in pixels
        public void SetMarkerWidth(int new_width)
        {
            Drawable.Pen_Width = new_width;
        }
        public void SetMarkerWidth(float new_width)
        {
            SetMarkerWidth((int)new_width/10);
        }

        public void SetTransparency(float amount)
        {
            Transparency = amount/100;
            Color c = Drawable.Pen_Colour;
            c.a = amount/100;
            Drawable.Pen_Colour = c;
        }


        // Call these these to change the pen settings
        public void SetMarkerRed()
        {
             c = Color.red;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Debug.Log("Red clicked");
        }
        public void SetMarkerGreen()
        {
             c = Color.green;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerBlue()
        {
             c = Color.blue;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerMagenta()
        {
             c = Color.magenta;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerBlack()
        {
             c = Color.black;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetMarkerYellow()
        {
             c = Color.yellow;
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
        }
        public void SetEraser()
        {
            //SetMarkerColour(new Color(255f, 255f, 255f, 0f));
            SetMarkerColour(Color.white);

        }

        public void PartialSetEraser()
        {
            SetMarkerColour(new Color(255f, 255f, 255f, 0.5f));
        }

        public void createQuad()
        {
            
            //Instance lel Quad fel postion mtaa laser
            currNewQuad =Instantiate(newQuad,PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewQuad.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollow = true;
           
        }


        public void releaseQuad()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if(onfollow) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
            currNewQuad.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y,GameObject.FindGameObjectWithTag("Plan").transform.position.z-0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollow)
                { currNewQuad.transform.parent = null; onfollow = false; }
                
            }
        }



        public void createTriangle()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewTriangle = Instantiate(newTriangle, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewTriangle.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowT = true;

        }


        public void releaseTriangle()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowT) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewTriangle.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowT)
                { currNewTriangle.transform.parent = null; onfollowT = false; }

            }
        }




    }
}