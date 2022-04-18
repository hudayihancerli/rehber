using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace phone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> rehber = new List<Kisi>();

            void ekle(){
                Kisi kisi = new Kisi();

                Console.Write("Kişi adı : ");
                string Ad = Console.ReadLine();

                Console.Write("Kişi soyad : ");
                string Soyad =  Console.ReadLine();

                Console.Write("Kişi telno : ");
                string TelNo = Console.ReadLine();

                rehber.Add(new Kisi() {Ad = Ad, Soyad = Soyad, TelNo = TelNo});
                System.Console.WriteLine("Eklendi.");
            }
            void sil(){
                System.Console.Write("Lütfen rehberden silmek istediğiniz kişinin adını veya soyadını giriniz : ");
                string nameOrLastname = Console.ReadLine();
                bool isHave = false;

                for(int i= 0; i < rehber.Count; i++)//foreach kulandığımda hata aldım!
                {
                    if(rehber[i].Ad == nameOrLastname || rehber[i].Soyad == nameOrLastname){
                        isHave = true;
                        System.Console.WriteLine($"{rehber[i].Ad} adlı kişiyi silmek istiyor musunuz?(y,n)");
                        string isRemove = Console.ReadLine().ToLower();
                        if(isRemove == "n"){
                            System.Console.WriteLine("Silme işlemi iptal edilmiştir.");
                        }else if(isRemove == "y"){
                            rehber.Remove(rehber[i]);
                        }else{
                            System.Console.WriteLine("Lütfen y veya n harflerini giriniz.");
                        }
                    }
                }
                if(isHave == false){
                    System.Console.WriteLine("Kişi rehberde bulunamadı.");
                }else{
                    System.Console.WriteLine("Kişi silindi.");
                }
            }
            void güncelle(){
                System.Console.Write("Lütfen rehberden güncellemek istediğiniz kişinin adını veya soyadını giriniz : ");
                string nameOrLastname = Console.ReadLine();
                bool isHave = false;

                for(int i = 0; i < rehber.Count; i++){
                    if(rehber[i].Ad == nameOrLastname || rehber[i].Soyad == nameOrLastname){
                        isHave = true;
                        System.Console.WriteLine($"{rehber[i].Ad} adlı kişiyi güncellemek istiyor musunuz?(y,n)");
                        string isRemove = Console.ReadLine().ToLower();
                        if(isRemove == "n"){
                            System.Console.WriteLine("Güncelleme işleminiz iptal edilmiştir.");
                        }else if(isRemove == "y"){
                            System.Console.WriteLine("(1) isim\n(2) soyisim\n(3) telefon numrası");
                            int number = int.Parse(Console.ReadLine());
                            switch (number)
                            {
                                case 1: 
                                    System.Console.Write("Yeni ad : ");
                                    rehber[i].Ad = Console.ReadLine();
                                    break;
                                case 2: 
                                    System.Console.Write("Yeni soyad : ");
                                    rehber[i].Soyad = Console.ReadLine();
                                    break;
                                case 3: 
                                    System.Console.Write("Yeni telefon numarası : ");
                                    rehber[i].TelNo = Console.ReadLine();
                                    break;
                                default: System.Console.WriteLine("Lütfen sadece 1, 2 veya 3 tuşuna tıklayınız."); break;
                            }
                        }
                    }
                }
                if(isHave == false){
                    System.Console.WriteLine("Kişi bulunamadı");
                }else{
                    System.Console.WriteLine("Güncellendi");
                }
            }    
            void listele(){
                 System.Console.WriteLine("a-z için (1)");
                        System.Console.WriteLine("z-a için (2)");
                        int azza = int.Parse(Console.ReadLine());
                        if(azza == 1){
                            System.Console.WriteLine("***Rehber* A - Z**"); 
                            var rehberaz = from Kisi in rehber orderby Kisi.Ad select Kisi;
                            foreach (Kisi item in rehberaz)
                            {
                                Console.WriteLine($"Adı : {item.Ad}");
                                Console.WriteLine($"Soyadı : {item.Soyad}");
                                Console.WriteLine($"Telefon numarası : {item.TelNo}");
                            }
                            System.Console.WriteLine("************");
                        }else if(azza == 2){
                            System.Console.WriteLine("***Rehber* Z - A**"); 
                            var rehberza = from Kisi in rehber orderby Kisi.Ad descending select Kisi; 
                            foreach (Kisi item in rehberza)
                            {
                                Console.WriteLine($"Adı : {item.Ad}");
                                Console.WriteLine($"Soyadı : {item.Soyad}");
                                Console.WriteLine($"Telefon numarası : {item.TelNo}");
                            }
                            System.Console.WriteLine("************");
                        }else{
                            System.Console.WriteLine("Lütfen 1 veya 2 tuşuna tıklayınız.");
                        }
            }
            void arama(){
                System.Console.WriteLine("Ad ve soyada göre arama yapmak için : (1)\nTelefon numarasına göre arama yapmak için : (2)");
                int secim = int.Parse(Console.ReadLine());
                if(secim == 1){
                    System.Console.Write("Lütfen Aramak istediğiniz kişinin adını veya soyadını giriniz : ");
                    string nameOrLastname = Console.ReadLine();
                    for(int i = 0; i < rehber.Count; i++){
                        if(rehber[i].Ad == nameOrLastname || rehber[i].Soyad == nameOrLastname){
                            Console.WriteLine($"Adı : {rehber[i].Ad}");
                            Console.WriteLine($"Soyadı : {rehber[i].Soyad}");
                            Console.WriteLine($"Telefon numarası : {rehber[i].TelNo}");
                        }
                    }
                }else if(secim == 2){
                    System.Console.Write("Lütfen Aramak istediğiniz kişinin Telefon numarasını giriniz : ");
                    string telno = Console.ReadLine();
                    for(int i = 0; i < rehber.Count; i++){
                        if(rehber[i].TelNo == telno){
                            Console.WriteLine($"Adı : {rehber[i].Ad}");
                            Console.WriteLine($"Soyadı : {rehber[i].Soyad}");
                            Console.WriteLine($"Telefon numarası : {rehber[i].TelNo}");
                        }
                    }
                }else{
                    System.Console.WriteLine("Lütfen 1 veya 2 yazan tuşa tıklayınız.");
                }
            }

            do{
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                int islem = int.Parse(Console.ReadLine());
                switch (islem)
                {
                    case 1: ekle(); break;
                    case 2: sil(); break;
                    case 3: güncelle(); break;
                    case 4: listele(); break;
                    case 5: arama(); break;
                    default: break;
                }
           }while (true);

        }
    }
}