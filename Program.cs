List<Kendaraan> data_kendaraan = new List<Kendaraan>()
{
    new Kendaraan("Vario", 50000, "N 6767 FFF"),
    new Kendaraan("NMAX", 50000, "N 8888 AKU"),
    new Mobil("Civic", 120000, "N 0001 NTT"),
    new Mobil("Avanza", 115000, "N 2002 TKB"),
    new MiniBus("Elf", 195000, "N 9876 JBL"),
    new MiniBus("HiAce", 200000, "N 0670 AHO")
};
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
        Console.WriteLine($"Nama Kendaraan: {_namaKendaraan}");
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