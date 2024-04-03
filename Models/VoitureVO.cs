using LabMVC;

namespace LabMVC.Models
{
    public class VoitureVO
    {

        private int idVoiture;
        private string nomVoiture;
        private string urlImage;
        private string description;
        private int prix;

        public VoitureVO()
        {
        }

        public string NomVoiture { get => nomVoiture; set => nomVoiture = value; }
        public string Description { get => description; set => description = value; }
        public int Prix { get => prix; set => prix = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }
        public int IdVoiture { get => idVoiture; set => idVoiture = value; }
    }
}