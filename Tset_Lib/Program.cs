using LIB_C_BASE;

namespace Tset_Lib
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            C_BASE La_Base = new C_BASE();
            var result = La_Base.Emplacemen_Fichier_CSV(@"F:\Entreprise\catalogue_acadia.csv");

            if (result)
            {
                await La_Base.Creaion_Du_Json_Grace_Au_CSV();

                var Les_Processeur = await La_Base.Get_All_Objet_Informatique_By_Nom("Cartes graphiques");

                for (int i = 0; i < Les_Processeur.Count; i++)
                {
                    Console.WriteLine(Les_Processeur[i]);
                }
            }else Console.WriteLine("Le fichier csv n'est pas correcte");

            Console.ReadLine();
        }
    }
}
