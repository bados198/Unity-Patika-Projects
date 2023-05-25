public class PhoneBook {
    private string name;
    private string surname;
    private string telNo;

    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string TelNo { get => telNo; set => telNo = value; }

    public  void saveNumber(List<PhoneBook> phoneBook) {
        Console.Write("Ad gir: ");
        string name = Console.ReadLine();
        Console.Write("Soyadı gir: ");
        string surname = Console.ReadLine();
        Console.Write("Tel No gir: ");
        string telNo = Console.ReadLine();
        phoneBook.Add(new PhoneBook(){
            Name = name,
            Surname = surname,
            TelNo = telNo
        });
    }

    public void deleteNumber(List<PhoneBook> phoneBook) {
        int myChoice = 2;
        do{
            Console.Write("\nSilmek istediğin kişinin adı: ");
            string name = Console.ReadLine();
            Console.Write("Silmek istediğin kişinin soyadı: ");
            string surname = Console.ReadLine();

            int foundFlag = 0;
            foreach(var item in phoneBook) {
                if(item.Name.Equals(name) && item.Surname.Equals(surname)) {
                    foundFlag = 1;
                    Console.Write("{0} {1} kişi silinecektir. Onaylıyor musun? (e/h): ", name, surname);
                    string choice = Console.ReadLine();
                    if(choice.ToLower().Equals("e")) {
                        phoneBook.Remove(item);
                        Console.WriteLine("{0} {1} kişi silindi.", name, surname);
                        myChoice = 1; 
                        break;
                    }
                    else if(choice.ToLower().Equals("h")) {
                        Console.WriteLine("İptal");
                        break;
                    }
                    else
                        Console.WriteLine("Yanlış girdin. Geçerli bir tercih yap");
                }
            }
            if (foundFlag == 0) {

                Console.WriteLine("\nRehberde böyle bir kişi bulunamadı.");
                Console.WriteLine("* Silme işlemini bitirmek için : (1)\n* Yeniden denemek için : (2)");
                Console.Write("Seçim: ");
                myChoice = int.Parse(Console.ReadLine());
                if (myChoice == 1) {
                    Console.WriteLine("Silme işlemi bitiyor...");
                     break;
                }
                else if(myChoice == 2)
                    Console.WriteLine("Yeniden dene...");
                else{
                    Console.WriteLine("Geçerli seçim yap.");
                    break;
                }
            }
        }while(myChoice != 1);
    }

    public void updateNumber(List<PhoneBook> phoneBook) {
        int myChoice = 2;
        do{
            Console.Write("Güncellemek istediğin kişinin adını gir: ");
            string name = Console.ReadLine();
            Console.Write("Güncellemek istediğin kişinin soyadını gir: ");
            string surname = Console.ReadLine();

            int foundFlag = 0;
            foreach(var item in phoneBook) {
                if (item.Name.Equals(name) && item.Surname.Equals(surname)) {
                    foundFlag = 1;
                    Console.Write("Yeni telefonu gir: ");
                    string telNo = Console.ReadLine();
                    item.TelNo = telNo;
                    Console.WriteLine("{0} {1} kişisi güncellendi!", name, surname);
                    myChoice = 1;
                    break;
                }
            }

            if (foundFlag == 0) {
                Console.WriteLine("\nKişi rehberinde böyle bir kişi bulunamadı. Lütfen seçim yap.");
                Console.WriteLine(" * Güncelleme işlemini kapat : (1)\n* Yeniden gir : (2)");
                Console.Write("Seçim: ");
                if (myChoice == 1) {
                    Console.WriteLine("Güncelleme işlemi bitiriliyor...");
                    break;
                }
                else if(myChoice == 2)
                    Console.WriteLine("Yeniden deneniyor...");
                else{
                    Console.WriteLine("Geçerli bir seçim yap.");
                    break;
                }
            }
        }while(myChoice != 1);
    }

    public void listBook(List<PhoneBook> phoneBook) {
        Console.WriteLine("Kişi Rehberi");
        Console.WriteLine("**********************************");
        foreach(var item in phoneBook) {
            Console.WriteLine("Ad: {0}",item.Name);
            Console.WriteLine("Soyadı: {0}",item.Surname);
            Console.WriteLine("TelNo: {0}",item.TelNo);
            Console.WriteLine("----------------------------------");
        }
    }

    public void searchBook(List<PhoneBook> phoneBook) {
        Console.WriteLine("Arama yapmak istediğin kişiyi seç.");
        Console.WriteLine("***************************************\n");
        Console.WriteLine("Ad ve Soyadı ile: (1)");
        Console.WriteLine("Telefon numarası ile: (2)");
        int choice;
        string name = "smth", surname = "smth", telNo = "smth"; //giving default values for comparing
        do{
            Console.Write("Seçim: ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1) {
                Console.Write("Arama yapmak istediğin kişinin adını gir: ");
                name = Console.ReadLine();
                Console.Write("Arama yapmak istediğin kişinin soyadını gir: ");
                surname = Console.ReadLine();

            }
            else if (choice == 2) {
                Console.Write("ETel No İle Arama Yapmak İçin Numarayı Gir: ");
                telNo = Console.ReadLine();
            }
            else
                Console.WriteLine("Geçerli Seçim Yap");
        }while(choice != 1 && choice != 2);

        Console.WriteLine("YArama Sonucu:");
        Console.WriteLine("***************************************\n");
        int foundFlag = 0;
        if (choice == 1) {
            foreach(var item in phoneBook) {
                if (item.Name.Equals(name) && item.Surname.Equals(surname)) {
                    Console.WriteLine("Girdiğin Ad ve Soyadı İle Arama Yapılıyor");
                    Console.WriteLine("Ad: {0}",item.Name);
                    Console.WriteLine("Soyadı: {0}",item.Surname);
                    Console.WriteLine("Tel No: {0}",item.TelNo);
                    Console.WriteLine("----------------------------------");
                    foundFlag = 1;    
                }  
            }
        }
        else if (choice == 2) {
            foreach(var item in phoneBook) {
                if (item.TelNo.Equals(telNo)) {
                    Console.WriteLine("Tel No İle Arama Yapılıyor");
                    Console.WriteLine("Ad: {0}",item.Name);
                    Console.WriteLine("Soyadı: {0}",item.Surname);
                    Console.WriteLine("Tel No: {0}",item.TelNo);
                    Console.WriteLine("----------------------------------");
                    foundFlag = 1;    
                }
            }
        }

        if (foundFlag == 0)
            Console.WriteLine("Kişi Rehberde Kayıtlı Değil");
    }
}
