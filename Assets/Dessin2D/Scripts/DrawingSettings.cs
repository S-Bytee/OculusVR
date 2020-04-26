using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
        public GameObject newCercle;
        public GameObject currNewCercle;
        public bool onfollow = false;
        public bool onfollowT = false;
        public bool onfollowC = false;
        public Color c  = Color.black;
        public GameObject Panel;
        public GameObject Panel2;
        public GameObject newA;
        public GameObject currNewA;
        public bool onfollowA = false;
        public GameObject newB;
        public GameObject currNewB;
        public bool onfollowB = false;
        public GameObject newC;
        public GameObject currNewC;
        public bool onfollowCC = false;
        public GameObject newD;
        public GameObject currNewD;
        public bool onfollowD = false;
        public GameObject newE;
        public GameObject currNewE;
        public bool onfollowE = false;
        public GameObject newF;
        public GameObject currNewF;
        public bool onfollowF = false;
        public GameObject newG;
        public GameObject currNewG;
        public bool onfollowG = false;
        public GameObject newH;
        public GameObject currNewH;
        public bool onfollowH = false;
        public GameObject newI;
        public GameObject currNewI;
        public bool onfollowI = false;

        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width


        public void Update()
        {
            releaseQuad();
            releaseTriangle();
            releaseCercle();
            releaseA();
            releaseB();
            releaseC();
            releaseD();
            releaseE();
            releaseF();
            releaseG();
            releaseH();
            releaseI();
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

        public void createCercle()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewCercle = Instantiate(newCercle, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewCercle.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowC = true;

        }


        public void releaseCercle()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowC) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewCercle.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowC)
                { currNewCercle.transform.parent = null; onfollowC = false; }

            }
        }
        public void openPanel()
        {

            if (Panel != null)
            {
                bool isActif = Panel.activeSelf;
                Panel.SetActive(!isActif);

            }




        }
        public void openPanel2()
        {

            if (Panel2 != null)
            {
                bool isActif = Panel2.activeSelf;
                Panel2.SetActive(!isActif);

            }




        }

        public void createA()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewA = Instantiate(newA, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewA.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowA = true;

        }


        public void releaseA()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowA) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewA.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowA)
                { currNewA.transform.parent = null; onfollowA = false; }

            }
        }

        public void createB()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewB = Instantiate(newB, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewB.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowB = true;

        }


        public void releaseB()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowB) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewB.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowB)
                { currNewB.transform.parent = null; onfollowB = false; }

            }
        }

        public void createC()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewC = Instantiate(newC, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewC.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowCC = true;

        }


        public void releaseC()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowCC) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewC.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowCC)
                { currNewC.transform.parent = null; onfollowCC = false; }

            }
        }


        public void createD()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewD = Instantiate(newD, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewD.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowD = true;

        }


        public void releaseD()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowD) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewD.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowD)
                { currNewD.transform.parent = null; onfollowD = false; }

            }
        }

        public void createE()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewE = Instantiate(newE, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewE.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowE = true;

        }


        public void releaseE()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowE) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewE.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowE)
                { currNewE.transform.parent = null; onfollowE = false; }

            }
        }

        public void createF()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewF = Instantiate(newF, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewF.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowF = true;

        }


        public void releaseF()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowF) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewF.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowF)
                { currNewF.transform.parent = null; onfollowF = false; }

            }
        }
        public void createG()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewG = Instantiate(newG, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewG.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowG = true;

        }


        public void releaseG()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowG) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewG.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowG)
                { currNewG.transform.parent = null; onfollowG = false; }

            }
        }
        public void createH()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewH = Instantiate(newH, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewH.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowH = true;

        }


        public void releaseH()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowH) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewH.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowH)
                { currNewH.transform.parent = null; onfollowH = false; }

            }
        }
        public void createI()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewI = Instantiate(newI, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewI.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowI = true;

        }


        public void releaseI()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowI) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewI.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowI)
                { currNewI.transform.parent = null; onfollowI = false; }

            }
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(sceneName: "Drawing_3D");
            Debug.Log("Scene changed");
        }

        public void reloadscene() { 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}