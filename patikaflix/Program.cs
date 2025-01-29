

class Dizi
{
    public string Adi { get; set; }
    public int YapimYili { get; set; }
    public string Turu { get; set; }
    public int YayinYili { get; set; }
    public string Yonetmen { get; set; }
    public string Platform { get; set; }

    public Dizi(string adi, int yapimYili, string turu, int yayinYili, string yonetmen, string platform)
    {
        Adi = adi ?? throw new ArgumentNullException(nameof(adi));
        YapimYili = yapimYili;
        Turu = turu ?? throw new ArgumentNullException(nameof(turu));
        YayinYili = yayinYili;
        Yonetmen = yonetmen ?? throw new ArgumentNullException(nameof(yonetmen));
        Platform = platform ?? throw new ArgumentNullException(nameof(platform));
    }
}

class KomediDizisi
{
    public string Adi { get; set; }
    public string Turu { get; set; }
    public string Yonetmen { get; set; }

    public KomediDizisi(string adi, string turu, string yonetmen)
    {
        Adi = adi ?? throw new ArgumentNullException(nameof(adi));
        Turu = turu ?? throw new ArgumentNullException(nameof(turu));
        Yonetmen = yonetmen ?? throw new ArgumentNullException(nameof(yonetmen));
    }

    public override string ToString()
    {
        return $"Dizi Adı: {Adi}, Türü: {Turu}, Yönetmen: {Yonetmen}";
    }
}

class Program
{
    static List<Dizi> DiziEkle()
    {
        List<Dizi> diziler = new List<Dizi>();
        while (true)
        {
            Console.Write("Dizi Adı: ");
            string adi = Console.ReadLine() ?? "";
            Console.Write("Yapım Yılı: ");
            int yapimYili;
            while (!int.TryParse(Console.ReadLine(), out yapimYili))
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayı girin:");
            }
            Console.Write("Türü: ");
            string turu = Console.ReadLine() ?? "";
            Console.Write("Yayınlanmaya Başlama Yılı: ");
            int yayinYili;
            while (!int.TryParse(Console.ReadLine(), out yayinYili))
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayı girin:");
            }
            Console.Write("Yönetmen: ");
            string yonetmen = Console.ReadLine() ?? "";
            Console.Write("Yayınlandığı İlk Platform: ");
            string platform = Console.ReadLine() ?? "";

            Dizi dizi = new Dizi(adi, yapimYili, turu, yayinYili, yonetmen, platform);
            diziler.Add(dizi);

            Console.Write("Yeni bir dizi eklemek istiyor musunuz? (E/H): ");
            string devam = Console.ReadLine() ?? "";
            if (!devam.Equals("E", StringComparison.OrdinalIgnoreCase))
                break;
        }
        return diziler;
    }

    static List<KomediDizisi> KomediDizileriniFiltrele(List<Dizi> diziler)
    {
        return diziler
            .Where(d => d.Turu.Equals("komedi", StringComparison.OrdinalIgnoreCase))
            .Select(d => new KomediDizisi(d.Adi, d.Turu, d.Yonetmen))
            .ToList();
    }

    static void ListeyiYazdir(List<KomediDizisi> komediDizileri)
    {
        var siraliListe = komediDizileri
            .OrderBy(d => d.Adi)
            .ThenBy(d => d.Yonetmen)
            .ToList();

        foreach (var dizi in siraliListe)
        {
            Console.WriteLine(dizi);
        }
    }

    static void Main(string[] args)
    {
        List<Dizi> diziler = DiziEkle();
        List<KomediDizisi> komediDizileri = KomediDizileriniFiltrele(diziler);
        ListeyiYazdir(komediDizileri);
    }
}