using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace RemoveFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "C:\\Users\\Rafael Machado\\Desktop";
            string originalFilePathSolar = "C:\\Users\\Rafael Machado\\Desktop\\MerraMissingdataSolar.txt";
            string originalFilePathWind = "C:\\Users\\Rafael Machado\\Desktop\\Merra Missing dataWind.txt";
            string noNameFilePathSolar = "C:\\Users\\Rafael Machado\\Desktop\\MerraMissingSolar.txt";
            string noNameFilePathWind = "C:\\Users\\Rafael Machado\\Desktop\\MerraMissingWind.txt";
            string batSolar = "C:\\Users\\Rafael Machado\\Desktop\\MerraSolarReady.bat";
            string batWind = "C:\\Users\\Rafael Machado\\Desktop\\MerraWindReady.bat";
            string brazilFPW = "C:\\Users\\Rafael Machado\\Desktop\\missingBrazilWind.txt";
            string brazilCleanWind = "C:\\Users\\Rafael Machado\\Desktop\\brazilCleanWind.txt";
            string brazilWindBatch = "C:\\Users\\Rafael Machado\\Desktop\\_brazilWind.bat";
            string brazilFPS = "C:\\Users\\Rafael Machado\\Desktop\\missing_Brazil_solar.txt";
            string brazilCleanSolar = "C:\\Users\\Rafael Machado\\Desktop\\brazilCleanSolar.txt";
            string brazilSolarBatch = "C:\\Users\\Rafael Machado\\Desktop\\_brazilSolar.bat";
            string indiaFPS = "C:\\Users\\Rafael Machado\\Desktop\\missing_india_solar.txt";
            string indiaCleanSolar = "C:\\Users\\Rafael Machado\\Desktop\\indiaCleanSolar.txt";
            string indiaBatch = "C:\\Users\\Rafael Machado\\Desktop\\_indiaSolar.bat";
            string indiaFPW = "C:\\Users\\Rafael Machado\\Desktop\\missing_india_wind.txt";
            string indiaCleanwind = "C:\\Users\\Rafael Machado\\Desktop\\indiaCleanWind.txt";
            string indiaWindBatch = "C:\\Users\\Rafael Machado\\Desktop\\_indiaWind.bat";
            string naFPS = "C:\\Users\\Rafael Machado\\Desktop\\missing_na.txt";
            string naCleanSolar = "C:\\Users\\Rafael Machado\\Desktop\\naCleanSolar.txt";
            string naBatch = "C:\\Users\\Rafael Machado\\Desktop\\naSolar.bat";
            string naFPW = "C:\\Users\\Rafael Machado\\Desktop\\missing_na_wind.txt";
            string naCleanWind = "C:\\Users\\Rafael Machado\\Desktop\\naCleanwind.txt";
            string naWindBatch = "C:\\Users\\Rafael Machado\\Desktop\\_nawind.bat";


           //CleanFile(naFPW, naCleanWind);
          // CreateBath(naCleanWind, naWindBatch, "WINDANDTEMP", "na");

            CleanFile(brazilFPW, brazilCleanWind);
            CreateBath(brazilCleanWind, brazilWindBatch, "WINDANDTEMP", "b");

            CleanFile(indiaFPW, indiaCleanwind);
            CreateBath(indiaCleanwind, indiaWindBatch, "WINDANDTEMP", "I");

           // CleanFile(brazilFPS, brazilCleanSolar);
           // CreateBath(brazilCleanSolar, brazilSolarBatch, "solar", "b");

            //CleanFile(indiaFPS, indiaCleanSolar);
           //CreateBath(indiaCleanSolar, indiaBatch, "solar", "i");

        }

        public static void CreateBath(string inFilePath, string outFilePath, string dataType, string location )
        {
            var list = new List<string>();
            HashSet<string> previousLines = new HashSet<string>();

            using (StreamReader reader = File.OpenText(inFilePath))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    if (previousLines.Add(line)) // 
                    {
                        list.Add(line);
                    }
                }
            }

            list = list.OrderBy(f => f).ToList(); // sort list
            string startDate = null;
            string endtDate = null;
            var sd = Convert.ToDateTime(startDate);

            using (StreamWriter file = new StreamWriter(outFilePath))
            {
                foreach (string s in list)
                {
                    startDate = s.Substring(1, 10);
                    endtDate = s.Substring(21, 10);
                    sd = Convert.ToDateTime(startDate);
                    sd = sd.AddDays(1);
                    startDate = sd.ToString("yyyy-MM-dd");

                    if (dataType.ToUpper() == "SOLAR" && location.ToUpper() == "NA")
                    {
                        //file.WriteLine(s);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"76.000\" /S:\"52.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-59.000\" /W:\"-172.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"52.000\" /S:\"34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-50.000\" /W:\"-137.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"34.000\" /S:\"22.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-125.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"22.000\" /S:\"04.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-110.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\"\r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\"\r\n");

                    }
                    if (dataType.ToUpper() == "WINDANDTEMP" && location.ToUpper() == "NA")
                    {
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"76.000\" /S:\"52.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-59.000\" /W:\"-172.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"52.000\" /S:\"34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-50.000\" /W:\"-137.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"34.000\" /S:\"22.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-125.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"22.000\" /S:\"04.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-110.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n", startDate, endtDate);

                        
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n");
                        
                    }
                    // Brazil solar
                    if (dataType.ToUpper() == "SOLAR" && location.ToUpper() == "B")
                    {
                        
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"5.000\" /S:\"-13.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-73.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"-10.000\" /S:\"-20.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"-18.000\" /S:\"-26.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-38.000\" /W:\"-63.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"-24.000\" /S:\"-34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-47.000\" /W:\"-62.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output3\" /dt:\"SOLAR\" \r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output0\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output1\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output2\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\brazil\\mer\" /DataOutputPath:\".\\brazil_solarMissing\\brazil\\output3\" /dt:\"SOLAR\"\r\n");



                    }
                    // India Solar
                    if (dataType.ToUpper() == "SOLAR" && location.ToUpper() == "I")
                    {
                       
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"32.000\" /S:\"23.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"24.000\" /S:\"19.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"20.000\" /S:\"12.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"14.000\" /S:\"3.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output3\" /dt:\"SOLAR\"\r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output0\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output1\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output2\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\india\\output3\" /dt:\"SOLAR\"\r\n");



                    }
                    // wind brazil
                    if (dataType.ToUpper() == "WINDANDTEMP" && location.ToUpper() == "B")
                    {
                        //file list
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"5.000\" /S:\"-13.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-73.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"-10.000\" /S:\"-20.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"-18.000\" /S:\"-26.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-38.000\" /W:\"-63.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"-24.000\" /S:\"-34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-47.000\" /W:\"-62.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\" \r\n", startDate, endtDate);

                        // download
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n");

                    }
                    // wind india
                    if (dataType.ToUpper() == "WINDANDTEMP" && location.ToUpper() == "I")
                    {
                        
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"32.000\" /S:\"23.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"24.000\" /S:\"19.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"20.000\" /S:\"12.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"14.000\" /S:\"3.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n", startDate, endtDate);

                        
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n");
                        
                    }
                    if (dataType.ToUpper() == "SOLAR" && location.ToUpper() == "ALL")
                    {

                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"76.000\" /S:\"52.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-59.000\" /W:\"-172.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"52.000\" /S:\"34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-50.000\" /W:\"-137.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"34.000\" /S:\"22.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-125.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"22.000\" /S:\"04.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-110.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\"\r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"5.000\" /S:\"-13.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-73.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"-10.000\" /S:\"-20.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"-18.000\" /S:\"-26.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-38.000\" /W:\"-63.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"-24.000\" /S:\"-34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-47.000\" /W:\"-62.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\" \r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"32.000\" /S:\"23.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"24.000\" /S:\"19.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"20.000\" /S:\"12.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"14.000\" /S:\"3.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\"\r\n", startDate, endtDate);

                        
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output0\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output1\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output2\" /dt:\"SOLAR\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\solarMissing\\output3\" /dt:\"SOLAR\"\r\n");
                        
                    }
                    if (dataType.ToUpper() == "WINDANDTEMP" && location.ToUpper() == "ALL")
                    {
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"76.000\" /S:\"52.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-59.000\" /W:\"-172.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"52.000\" /S:\"34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-50.000\" /W:\"-137.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"34.000\" /S:\"22.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-125.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"22.000\" /S:\"04.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-67.000\" /W:\"-110.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"5.000\" /S:\"-13.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-73.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"-10.000\" /S:\"-20.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-34.000\" /W:\"-70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"-18.000\" /S:\"-26.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-38.000\" /W:\"-63.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"-24.000\" /S:\"-34.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"-47.000\" /W:\"-62.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\" \r\n", startDate, endtDate);

                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M000\" /N:\"32.000\" /S:\"23.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M001\" /N:\"24.000\" /S:\"19.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"88.000\" /W:\"70.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M002\" /N:\"20.000\" /S:\"12.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"", startDate, endtDate);
                        file.WriteLine(".\\MerraDownloader.exe /RunName:\"M003\" /N:\"14.000\" /S:\"3.000\" /SD:\"{0}\" /ED:\"{1}\" /E:\"87.000\" /W:\"68.000\" /tp:1 /pi:0 /wdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n", startDate, endtDate);

                        
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M000\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output0\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M001\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output1\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M002\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output2\" /dt:\"WINDANDTEMP\"");
                        file.WriteLine(".\\MerraDownloader.exe /RN:\"M003\" /tp:1 /pi:0 /gd /rdf /FileListDataFilePrefix:\".\\fileList\\mer\" /DataOutputPath:\".\\windMissing\\output3\" /dt:\"WINDANDTEMP\"\r\n");
                        
                    }
                }
            }
        }

        public static void CleanFile(string inFilePath, string outFilePath)
        {
            var list = new List<string>();
            HashSet<string> previousLines = new HashSet<string>();

            using (StreamReader reader = File.OpenText(inFilePath))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    if (previousLines.Add(line)) // 
                    {
                        list.Add(line);
                    }
                }
            }

            list = list.OrderBy(f => f).ToList(); // sort list           

            using (StreamWriter file = new StreamWriter(outFilePath))
            {
                foreach (string s in list)
                {
                    if (!s.Contains("Missing info on"))
                    {
                        file.WriteLine(s);
                    }
                }
            }
        }
    }
}
