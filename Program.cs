using System.Threading.Channels;

List<Kendaraan> data_kendaraan = new List<Kendaraan>()
{
    new Kendaraan("Vario", 50000, "N 6767 DES"),
    new Kendaraan("Beat", 100000, "N 7777 FAS"),
    new Kendaraan("NMAX", 50000, "N 8888 KAM"),
    new Mobil("Civic", 120000, "N 0001 SPK"),
    new Mobil("Avanza", 115000, "N 2002 TGG"),
    new MiniBus("Elf", 195000, "N 9876 NTA"),
    new MiniBus("HiAce", 200000, "N 0670 AHO")
};

while (true)
{
    Console.Clear();

    Console.WriteLine(" ---Rental Kendaraan Fahri--- ");
    Console.WriteLine("\n Daftar Kendaraan");
    foreach (var dk in data_kendaraan)
    {
        dk.tampilkanInfo();
    }

    Console.Write("\nSilahkan Pilih Menu:");
    Console.WriteLine("\n1. Sewa\n2. Kembali\n3. Keluar");
    Console.Write("Masukkan Pilihan: ");
    string pilihan = Console.ReadLine();

    if (pilihan == "1")
    {
        //proses sewa

        Console.WriteLine("\nInput nama Kendaraan: ");
        string nama_Kendaraan = Console.ReadLine();

        var cari_Kendaraan = data_kendaraan.FirstOrDefault(ck => string.Equals(nama_Kendaraan, ck.NamaKendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_Kendaraan == null)
        {
            Console.WriteLine("\n Kendaraan tidak ditemukan");

        }
        else if (cari_Kendaraan.isAvailable)
        {
            Console.WriteLine("\nInput jumlah hari sewa: ");
            int hari = int.Parse(Console.ReadLine());

            double total_sewa = cari_Kendaraan.hitungTotal(hari);

            cari_Kendaraan.ubahStatusKetersediaan();

            Console.Write($"Total pembayaran sewa: Rp {total_sewa}");

        }
        else
        {
            Console.WriteLine("\nKendaraan tidak tersedia");
        }

    }
    else if (pilihan == "2")
    {
        //proses kembali

        Console.WriteLine("\nInput nama Kendaraan: ");
        string nama_Kendaraan = Console.ReadLine();

        var cari_Kendaraan = data_kendaraan.FirstOrDefault(ck => string.Equals(nama_Kendaraan, ck.NamaKendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_Kendaraan == null)
        {
            Console.WriteLine("\n Kendaraan tidak ditemukan");

        }
        else if (!cari_Kendaraan.isAvailable)
        {
            cari_Kendaraan.ubahStatusKetersediaan();
            Console.WriteLine("\nKendaraan berhasil dikembalikan");
        }
        else
        {
            Console.WriteLine("\nProses pengembalian tidak bisa dilakukan!");
        }

    }
    else if (pilihan == "3")
    {
        Console.WriteLine("\nTekan ENTER untuk menutup aplikasi..");
        Console.ReadLine();
        break;
    }
    else
    {
        Console.WriteLine("\nPilihan Invalid!");
    }
    Console.WriteLine("\nTekan ENTER untuk mengulang");
}

class Kendaraan
{
    protected string _namaKendaraan;
    protected double _hargaSewaPerHari;
    protected string _nomorPolisi;
    protected bool IsAvailable;

    public Kendaraan(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi)
    {
        _namaKendaraan = namaKendaraan;
        _hargaSewaPerHari = hargaSewaPerHari;
        _nomorPolisi = nomorPolisi;
        IsAvailable = true;
    }

    public string NamaKendaraan
    {
        get { return _namaKendaraan; }
        set { _namaKendaraan = value;}
        
    }
    public double hargaSewaPerHari
    {
        get {return  _hargaSewaPerHari;}
        set
        {
            {

                if (value > 0)
                {
                    _hargaSewaPerHari = value;
                }
                else
                {
                    Console.WriteLine("Harga sewa harus lebih besar dari 0");
                }

            }
        }

    }
    public string nomorPolisi
    {
        get {return _nomorPolisi;}
    }
    public bool isAvailable
    {
        get { return IsAvailable; }
    }

    public void tampilkanInfo()
    {
        Console.WriteLine($"\nNama Kendaraan: {_namaKendaraan}");
        Console.WriteLine($"Harga Sewa Per Hari: {_hargaSewaPerHari}");
        Console.WriteLine($"Nomor Polisi: {_nomorPolisi}");
        Console.WriteLine($"Ketersediaan: {(IsAvailable ? "Tersedia" : "Tidak Tersedia")}");
    }
   public void ubahStatusKetersediaan()
    {
        IsAvailable = !IsAvailable;
    }
    public virtual double hitungTotal(int jumlahHari)
    {
        return _hargaSewaPerHari * jumlahHari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi;
    public Mobil(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi)
     : base(namaKendaraan, hargaSewaPerHari, nomorPolisi)
    {
        _biayaAsuransi = 500000;
    }
    public override double hitungTotal(int jumlahHari)
    {
        return base.hitungTotal(jumlahHari) + _biayaAsuransi;
    }
}

class MiniBus : Kendaraan
{
    private double _biayaSopir;
    public MiniBus(string namaKendaraan, double hargaSewaPerHari, string nomorPolisi)
     : base(namaKendaraan, hargaSewaPerHari, nomorPolisi)
    {
        _biayaSopir = 100000;
    }
    public override double hitungTotal(int jumlahHari)
    {

        return base.hitungTotal(jumlahHari) + _biayaSopir * jumlahHari;

    }
}