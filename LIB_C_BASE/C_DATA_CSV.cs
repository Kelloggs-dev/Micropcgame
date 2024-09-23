
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LIB_C_BASE
{
    public class C_DATA_CSV
    {

        public async Task Transforme_Data_CSV_En_Json(string P_Fichier_CSV, string P_Fichier_Nom_Json)
        {
            //recup le fichier csv
            var Data_Ligne_CSV = await File.ReadAllLinesAsync(P_Fichier_CSV,Encoding.UTF8);

            await Task.Run(async () =>
            {

                //lire la premiere ligne qui contiens les en-tete en divisan la ligne grace au virgule
                var Headers = Data_Ligne_CSV[0].Split(';');
                var Dict_Data_CSV = new List<Dictionary<string, string>>();

                for (int Index = 1; Index < Data_Ligne_CSV.Length; Index++)
                {
                    //recup les valeurs a partir de a deuxieme ligne 
                    var Data = Data_Ligne_CSV[Index].Split(';');
                    var Dict = new Dictionary<string, string>();

                    for (int Index_2 = 0; Index_2 < Headers.Length; Index_2++)
                    {
                        //Aligner le header avec les data correspondantes
                        Dict[Headers[Index_2]] = Data[Index_2];
                    }

                    Dict_Data_CSV.Add(Dict);
                }

                await Save_Data_En_Json(Dict_Data_CSV, P_Fichier_Nom_Json);

            });
        }

        private async Task Save_Data_En_Json(List<Dictionary<string, string>> P_Data_CSV, string P_Fichier_Json)
        {
            // Configure JsonSerializerOptions pour éviter les échappements des caractères spéciaux
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
                WriteIndented = true
            };

            //serialiser la list de dictionnaire en format json puis cree le fichier json
            var Data_Json = await Task.Run(() => JsonSerializer.Serialize(P_Data_CSV, options));

            // S'assurer que le répertoire existe, sinon le créer
            Directory.CreateDirectory(Path.GetDirectoryName(P_Fichier_Json));

            // Écrire le fichier JSON dans le dossier AppData
            await File.WriteAllTextAsync(P_Fichier_Json, Data_Json, Encoding.UTF8);
        }

    }
}

