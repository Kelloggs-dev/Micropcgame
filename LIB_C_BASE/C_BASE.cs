using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace LIB_C_BASE
{
    public class C_BASE
    {
        public string MON_FICHIER_CSV { get; set; }
        private string MON_FICHIER_JSON {  get; set; }
        const string Nom_Du_Json = "catalogue_acadia.json";

        public List<C_OBJET_INFORMATIQUE> Les_Objets_Informaique { get; set; }

        public C_BASE()
        {
            // Obtenir le chemin vers le dossier LocalAppData
            var AppData_Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Construire le chemin complet du fichier JSON
            MON_FICHIER_JSON = Path.Combine(AppData_Path, "micropcgame", Nom_Du_Json);
        }

        public bool Emplacemen_Fichier_CSV(string P_Emplacemen_Fichier)
        {
            if (File.Exists(MON_FICHIER_JSON))
            {
                return true;
            } else
            {
                if (File.Exists(P_Emplacemen_Fichier))
                {
                    MON_FICHIER_CSV = P_Emplacemen_Fichier;

                    return true;

                } else return false;
            }
        } 

        public async Task Creaion_Du_Json_Grace_Au_CSV()
        {

            if (File.Exists(MON_FICHIER_JSON) == false)
            {
                C_DATA_CSV Data_CSV = new C_DATA_CSV();
                await Data_CSV.Transforme_Data_CSV_En_Json(MON_FICHIER_CSV, MON_FICHIER_JSON);
            }

            var Data_Json = await File.ReadAllTextAsync(MON_FICHIER_JSON,Encoding.UTF8);
            Les_Objets_Informaique = await Task.Run(() => JsonSerializer.Deserialize<List<C_OBJET_INFORMATIQUE>>(Data_Json));
            
        }

        public async Task<List<C_OBJET_INFORMATIQUE>> Get_All_Objet_Informatique_By_Nom(string P_Objet_Informatique)
        {

            return await Task.Run(() =>
            {
                var List_Objet_Informatique = new List<C_OBJET_INFORMATIQUE>();

                foreach (var Un_Objet_Informatique in Les_Objets_Informaique)
                {
                    if (Un_Objet_Informatique.FAMILLE == P_Objet_Informatique)
                    {
                        List_Objet_Informatique.Add(Un_Objet_Informatique);
                    }
                }
                return List_Objet_Informatique;
            });
            

        }

        

    }
}
