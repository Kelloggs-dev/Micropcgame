using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LIB_C_BASE
{
    public class C_OBJET_INFORMATIQUE
    {
        public string MARQUE { get; set; }
        public string FAMILLE { get; set; }

        [JsonPropertyName("Part Number")]
        public string PartNumber { get; set; }

        [JsonPropertyName("REF ACADIA")]
        public string REFACADIA { get; set; }

        [JsonPropertyName("EAN CODE")]
        public string EANCODE { get; set; }

        [JsonPropertyName("REF CONSTRUCTEUR")]
        public string REFCONSTRUCTEUR { get; set; }

        [JsonPropertyName("DESIGNATION 1")]
        public string DESIGNATION1 { get; set; }

        [JsonPropertyName("STOCK REEL")]
        public string STOCKREEL { get; set; }

        [JsonPropertyName("PRIX HT")]
        public string PRIXHT { get; set; }

        [JsonPropertyName("PRIX CLIENT")]
        public string PRIXCLIENT { get; set; }
        public string ECOTAXE { get; set; }

        [JsonPropertyName("COPIE PRIVEE")]
        public string COPIEPRIVEE { get; set; }
        public string POIDS { get; set; }
        public string IMAGE { get; set; }

        [JsonPropertyName("CATEGORIE PRINCIPALE")]
        public string CATEGORIEPRINCIPALE { get; set; }

        [JsonPropertyName("CATEGORIE SECONDAIRE")]
        public string CATEGORIESECONDAIRE { get; set; }

        [JsonPropertyName("CATEGORIE TERTIAIRE")]
        public string CATEGORIETERTIAIRE { get; set; }

        public override string ToString()
        {
            return $"Famille: {FAMILLE}, STOCKREEL: {STOCKREEL}, PRIXHT: {PRIXHT}, PRIXCLIENT: {PRIXCLIENT}";
        }

    }


}
