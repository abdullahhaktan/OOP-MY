using Microsoft.AspNetCore.Mvc;
using OOP_MY.Ornekler;

namespace OOP_MY.Controllers
{
    public class DefaultController : Controller
    {
        // Commented out method example
        //void islemler()
        //{
        //    Class1 c = new Class1();
        //    c.Topla();
        //}

        // Return a test sentence string
        string cumle()
        {
            string c = "deneme deneme deneme deneme deneme deneme deneme deneme deneme";
            return c;
        }

        // Action method for testing city and flag data
        public IActionResult Deneme()
        {
            Sehirler s = new Sehirler(); // Create city object
            Bayrak bayrak = new Bayrak(); // Create flag object

            // Set city properties
            s.Ad = "Ankara";
            s.Id = 1;
            s.Nüfus = 5000000;
            s.Ulke = "Türkiye";
            s.Renk1 = "Kırmızı";
            s.Renk2 = "Sarı";

            // Pass city data to view via ViewBag
            ViewBag.v1 = s.Ad; // City name
            ViewBag.v2 = s.Id; // City ID
            ViewBag.v3 = s.Nüfus; // Population
            ViewBag.v4 = s.Ulke; // Country

            s.Ad = "Üsküp"; // Update city name
            ViewBag.z1 = s.Ad; // Pass updated name to view

            return View(); // Return view
        }

        // Method to set message list in ViewBag
        void MesajListesi(string p)
        {
            ViewBag.v = p;
        }

        // Method to set username in ViewBag
        void Kullanıcı(string kullaniciAdi)
        {
            ViewBag.v = kullaniciAdi;
        }

        // Method to set multiple messages in ViewBag
        void mesajlar()
        {
            ViewBag.m1 = "Merhabalar bu bir core projesi"; // "Hello this is a Core project"
            ViewBag.m2 = "Merhaba Proje çok iyi duruyor"; // "Hello the project looks great"
            ViewBag.m3 = "Selamlar hi hello bonjour"; // "Greetings hi hello bonjour"
        }

        // Method to add two fixed numbers
        int topla()
        {
            int s1 = 20;
            int s2 = 30;
            int sonuc = s1 + s2;
            return sonuc;
        }

        // Method to add two parameterized numbers
        int Topla(int sayi1, int sayi2)
        {
            int sonuc = sayi1 + sayi2;
            return sonuc;
        }

        // Method to calculate rectangle perimeter
        int cevre()
        {
            int kisa = 10; // Short side
            int uzun = 20; // Long side
            int c = 2 * (kisa + uzun); // Perimeter formula: 2*(width+height)
            return c;
        }

        // Method to calculate factorial of a number
        int faktoriyel(int sayi)
        {
            var sonuc = 1;
            for (int i = 1; i <= sayi; i++)
            {
                sonuc = sonuc * i; // Multiply result by each number from 1 to n
            }
            int faktryl = sonuc;
            return faktryl;
        }

        // Main index action method
        public IActionResult Index()
        {
            mesajlar(); // Call message method
            MesajListesi("Parametre ismi"); // Call message list method with parameter
            Kullanıcı("Admin Kullanıcı"); // Call user method

            ViewBag.v = Topla(2, 3); // Calculate 2+3 and pass to ViewBag

            // Note: Console.ReadLine() doesn't work in ASP.NET Core web applications
            // This would need to be handled differently (form input, etc.)
            Console.WriteLine("Lütfen faktöriyelini hesaplamak istediğiniz sayıyı giriniz: ");
            int sayi = int.Parse(Console.ReadLine()); // This will cause runtime error in web app
            int sonuc = faktoriyel(sayi);
            ViewBag.fak = sonuc;

            return View(); // Return view
        }

        // Products action method
        public IActionResult Urunler()
        {
            mesajlar(); // Call messages
            ViewBag.t = topla(); // Pass addition result
            ViewBag.c = cevre(); // Pass perimeter result
            ViewBag.f = faktoriyel(5); // Pass factorial of 5
            Kullanıcı("Admin004"); // Set username
            return View(); // Return view
        }

        // Customers action method
        public IActionResult Musteriler()
        {
            ViewBag.d = cumle(); // Pass test sentence
            Kullanıcı("Admin004"); // Set username
            return View(); // Return view
        }
    }
}