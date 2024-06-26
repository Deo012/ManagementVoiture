﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMVC.Models
{
    public class ClientVO
    {
        #region Variables et Objets de Cours
        /// <summary>
        /// Désigne le numéro du client.
        /// </summary>
        private int numeroClient;

        
        private string prenom;
        private string nom;
        private string adresse;
        private string ville;
        private string pays;
        private string codepostal;
        private int voitureCommande;
        #endregion

        #region Constructeur de Cours
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursVO"/> class.
        /// Constructeur de CoursVO créant un objet ayant les attributs 
        /// passé en paramètres provenant de CoursDAO - qui accède la base de donnée.
        /// </summary>
        public ClientVO()
        {
        }
        #endregion

        #region Accesseurs et Mutateurs pour Cours
        /// <summary>
        /// Gets or sets pour numeroCours.
        /// </summary>
        public int NumeroClient
        {
            get { return this.numeroClient; }
            set { this.numeroClient = value; }
        }

        /// <summary>
        /// Gets or sets pour titreCours.
        /// </summary>
        public string NomClient
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public int VoitureCommande
        {
            get { return this.voitureCommande; }
            set { this.voitureCommande = value; }
        }

        public string Adresse { get => adresse; set => adresse = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Pays { get => pays; set => pays = value; }
        public string Codepostal { get => codepostal; set => codepostal = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        #endregion
    }
}
