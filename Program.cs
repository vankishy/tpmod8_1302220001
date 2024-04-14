using tpmodul8_1302220001;
public class Program
{
    private static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int jmlHari = int.Parse(Console.ReadLine());

        if ((config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) || (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5) && jmlHari < config.BatasHariDemam)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
        config.UbahSatuan();
    }
}