using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Karesz
{
    public partial class Form1 : Form
    {

        // IDE JÖNNEK AZ ELJÁRÁSOK ÉS FÜGGVÉNYEK
        void Hátraarc()
        {
            Fordulj(jobbra);
            Fordulj(jobbra);
        }

        void Lépj(int n) // --> ez egy számparaméter
        {
            if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Lépj();
                }
            }
            else // tehát n < 0
            {
                Hátraarc();
                for (int i = 0; i < -n; i++)
                {
                    Lépj();
                }
                Hátraarc();
            }
        }

        void Rakj_és_lépj(int n, int szin = fekete)
        {
            for (int i = 0; i < n; i++)
            {
                Tegyél_le_egy_kavicsot(szin);
                Lépj();
            }
        }
        void ferde_vonal1()
        {
            for (int i = 0; i < 10; i++)
            {
                Rakj_és_lépj(1);
                Fordulj(jobbra);
                Lépj(1);
                Fordulj(balra);
            }

        }

        void vonal1()
        {
            Rakj_és_lépj(14);
        }
        void DIÁK_ROBOTJAI()
        {
            Robot.Get("Karesz").Feladat = delegate ()
            {
                ferde_vonal1();
                Lépj(-1);
                Fordulj(jobbra);
                vonal1();
                ferde_vonal1();
                Fordulj(balra);
                Lépj(1);
                Fordulj(balra);
                Lépj(1);
                vonal1();
                vonal1();
                Rakj_és_lépj(5);
            };
        }

    }
}





/* USERS MANUAL -- LEGFONTOSABB PARANCSOK

MOZGÁSOK

Lépj();                          -------- Karesz előre lép egyet.
Fordulj(jobbra);                 -------- Karesz jobbra fordul.
Fordulj(balra);                  -------- Karesz balra fordul.
Vegyél_fel_egy_kavicsot();       -------- Karesz felvesz egy kavicsot.
Tegyél_le_egy_kavicsot();        -------- Karesz letesz egy fekete kavicsot
Tegyél_le_egy_kavicsot(piros);   -------- Karesz letesz egy piros kavicsot.

Minden mozgás után a robot köre véget ér és a következő robot jön. 

SZENZOROK

Van_e_előttem_fal();        -------- igaz, ha Karesz fal előtt áll, egyébként hamis.
Kilépek_e_a_pályáról();     -------- igaz, ha Karesz a pálya szélén kifele néz, egyébként hamis.
Van_e_itt_Kavics();         -------- igaz, ha Karesz épp kavicson áll, egyébként hamis.
Köveinek_száma_ebből(piros) -------- Karesz piros köveinek a száma.
Mi_van_alattam();           -------- a kavics színe, amin Karesz áll. (Ez igazából egy szám!)
Ultrahang();                -------- a Karesz előtt található tárgy távolsága. Ez a tárgy lehet fal vagy másik robot is. 
SzélesUltrahang();          -------- ugyanaz, mint az ultrahangszenzor, de ez nem csak a Karesz előtti mezőket pásztázza, hanem a szomszédos mezőket is. Egy számhármast ad vissza. 
Hőmérséklet();              -------- a Karesz által mért hőmérséklet. A láva forrása 1000 fok, amitől lépésenként távolodva a hőmérséklet 200 fokonként hűl. Az alapértelmezett hőmérséklet 0 fok.

A szenzorokat bármennyiszer használhatja a robot a saját körén belül.
*/