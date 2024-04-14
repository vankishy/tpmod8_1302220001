using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302220001
{
    internal class CovidConfig
    {
        private const string filePath = "covid_config.json";
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        private ConfigJSON covidConfig;

        public CovidConfig()
        {
            if (File.Exists(filePath))
            {
                string configJsonData = File.ReadAllText(filePath);
                covidConfig = JsonSerializer.Deserialize<ConfigJSON>(configJsonData);
            }
            else
            {
                covidConfig = new ConfigJSON();
                WriteNewConfigFile();
            }
        }

        public string SatuanSuhu
        {
            get { return covidConfig.satuan_suhu; }
            set { covidConfig.satuan_suhu = value; }
        }

        public int BatasHariDemam
        {
            get { return covidConfig.batas_hari_demam; }
            set { covidConfig.batas_hari_demam = value; }
        }

        public string PesanDitolak
        {
            get { return covidConfig.pesan_ditolak; }
            set { covidConfig.pesan_ditolak = value; }
        }

        public string PesanDiterima
        {
            get { return covidConfig.pesan_diterima; }
            set { covidConfig.pesan_diterima = value; }
        }

        public void WriteNewConfigFile()
        {
            string jsonString = JsonSerializer.Serialize(covidConfig, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
            WriteNewConfigFile();
        }

        class ConfigJSON
        {
            public ConfigJSON()
            {
                satuan_suhu = "celcius";
                batas_hari_demam = 14;
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
            }
            public string satuan_suhu { get; set; }
            public int batas_hari_demam { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }
        }
    }
}
