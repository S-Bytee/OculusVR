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
        
        
        public GameObject newJ;
        public GameObject currNewJ;
        public bool onfollowJ = false;
        public GameObject newK;
        public GameObject currNewK;
        public bool onfollowK = false;
        public GameObject newL;
        public GameObject currNewL;
        public bool onfollowL = false;
        public GameObject newM;
        public GameObject currNewM;
        public bool onfollowM = false;
        public GameObject newN;
        public GameObject currNewN;
        public bool onfollowN = false;
        public GameObject newO;
        public GameObject currNewO;
        public bool onfollowO = false;
        public GameObject newP;
        public GameObject currNewP;
        public bool onfollowP = false;
        public GameObject newQ;
        public GameObject currNewQ;
        public bool onfollowQ = false;
        public GameObject newR;
        public GameObject currNewR;
        public bool onfollowR = false;
        public GameObject newS;
        public GameObject currNewS;
        public bool onfollowS = false;
        public GameObject newT;
        public GameObject currNewT;
        public bool onfollowTT = false;
        public GameObject newU;
        public GameObject currNewU;
        public bool onfollowU = false;
        public GameObject newV;
        public GameObject currNewV;
        public bool onfollowV = false;
        public GameObject newW;
        public GameObject currNewW;
        public bool onfollowW = false;
        public GameObject newX;
        public GameObject currNewX;
        public bool onfollowX = false;
        public GameObject newY;
        public GameObject currNewY;
        public bool onfollowY = false;
        public GameObject newZ;
        public GameObject currNewZ;
        public bool onfollowZ = false;


        public GameObject wallDraw;
        public Material mat;
       


        public FlexibleColorPicker fcp;

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
            releaseJ();
            releaseK();
            releaseL();
            releaseM();
            releaseN();
            releaseO();
            releaseP();
            releaseQ();
            releaseR();
            releaseS();
            releaseT();
            releaseU();
            releaseV();
            releaseW();
            releaseX();
            releaseY();
            releaseZ();

            c = ColorIndicator.Instance.color.ToColor();
            SetMarkerColour(c);
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

        public void fcpChange()
        {
            c = fcp.color;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Debug.Log("fcp work!!");


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
            currNewQuad.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y,GameObject.FindGameObjectWithTag("Plan").transform.position.z-0.6f);
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





        public void createJ()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewJ = Instantiate(newJ, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewJ.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowJ = true;

        }


        public void releaseJ()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowJ) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewJ.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowJ)
                { currNewJ.transform.parent = null; onfollowJ = false; }

            }
        }
        public void createK()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewK = Instantiate(newK, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewK.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowK = true;

        }


        public void releaseK()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowK) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewK.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowK)
                { currNewK.transform.parent = null; onfollowK = false; }

            }
        }
        public void createL()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewL = Instantiate(newL, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewL.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowL = true;

        }


        public void releaseL()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowL) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewL.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowL)
                { currNewL.transform.parent = null; onfollowL = false; }

            }
        }
        public void createM()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewM = Instantiate(newM, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewM.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowM = true;

        }


        public void releaseM()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowM) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewM.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowM)
                { currNewM.transform.parent = null; onfollowM = false; }

            }
        }
        public void createN()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewN = Instantiate(newN, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewN.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowN = true;

        }


        public void releaseN()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowN) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewN.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowN)
                { currNewN.transform.parent = null; onfollowN = false; }

            }
        }
        public void createO()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewO = Instantiate(newO, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewO.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowO = true;

        }


        public void releaseO()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowO) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewO.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowO)
                { currNewO.transform.parent = null; onfollowO = false; }

            }
        }
        public void createP()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewP = Instantiate(newP, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewP.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowP = true;

        }


        public void releaseP()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowP) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewP.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowP)
                { currNewP.transform.parent = null; onfollowP = false; }

            }
        }
        public void createQ()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewQ = Instantiate(newQ, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewQ.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowQ = true;

        }


        public void releaseQ()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowQ) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewQ.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowQ)
                { currNewQ.transform.parent = null; onfollowQ = false; }

            }
        }
        public void createR()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewR = Instantiate(newR, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewR.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowR = true;

        }


        public void releaseR()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowR) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewR.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowR)
                { currNewR.transform.parent = null; onfollowR = false; }

            }
        }
        public void createS()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewS = Instantiate(newS, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewS.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowS = true;

        }


        public void releaseS()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowS) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewS.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowS)
                { currNewS.transform.parent = null; onfollowS = false; }

            }
        }
        public void createT()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewT = Instantiate(newT, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewT.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowTT = true;

        }


        public void releaseT()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowTT) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewT.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowT)
                { currNewT.transform.parent = null; onfollowTT = false; }

            }
        }
        public void createU()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewU = Instantiate(newU, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewU.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowU = true;

        }


        public void releaseU()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowU) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewU.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowU)
                { currNewU.transform.parent = null; onfollowU = false; }

            }
        }
        public void createV()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewV = Instantiate(newV, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewV.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowV = true;

        }


        public void releaseV()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowV) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewV.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowV)
                { currNewV.transform.parent = null; onfollowV = false; }

            }
        }
        public void createW()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewW = Instantiate(newW, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewW.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowW = true;

        }


        public void releaseW()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowW) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewW.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowW)
                { currNewW.transform.parent = null; onfollowW = false; }

            }
        }
        public void createX()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewX = Instantiate(newX, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewX.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowX = true;

        }


        public void releaseX()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowX) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewX.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowX)
                { currNewX.transform.parent = null; onfollowX = false; }

            }
        }
        public void createY()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewY = Instantiate(newY, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewY.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowY = true;

        }


        public void releaseY()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowY) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewY.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowY)
                { currNewY.transform.parent = null; onfollowY = false; }

            }
        }
        public void createZ()
        {

            //Instance lel Quad fel postion mtaa laser
            currNewZ = Instantiate(newZ, PhysicsPointer.Instance.CalculateEnd(), Quaternion.identity);
            currNewZ.transform.GetChild(0).GetComponent<Renderer>().material.color = c;
            //Ya Quad Ebda tabaa l laser
            onfollowZ = true;

        }


        public void releaseZ()
        {
            //Idha ken l quad saretlou l instanciation o onfollow true
            if (onfollowZ) // Donc l x o y mteeeou besh itaab3ou l laser o z mteeou besh itaaba l plan li tsaawer aalih bech akeka mayfoutech l plan o mayodhhorsh
                currNewZ.transform.position = new Vector3(PhysicsPointer.Instance.CalculateEnd().x, PhysicsPointer.Instance.CalculateEnd().y, GameObject.FindGameObjectWithTag("Plan").transform.position.z - 0.65f);
            if (PhysicsPointer.Instance.hit.collider)
            {
                //ken c bn nzeel aal souris o l quad lesaaak fel laser donc saybou ouin howaa 
                if (Input.GetMouseButtonDown(0) && onfollowZ)
                { currNewZ.transform.parent = null; onfollowZ = false; }

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
        public void changeBackgroundColor()
        {
            wallDraw.GetComponent<MeshRenderer>().material = mat;
        }
        

    }
}