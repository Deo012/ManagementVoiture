using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LabMVC.Models
{
    class ClientDAO
    {
        #region Variables de connexion
        /// <summary>
        /// Chaine de connexion.
        /// </summary>
        private string dp = "System.Data.SqlClient"; //DatabaseProvider

        /// <summary>
        /// Chaine de connexion.
        /// </summary>
        //private string cnStr = "Data Source=(local)\\MOB-C01203;Initial Catalog=Client;Integrated Security=True";
        private string cnStr = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Client;Integrated Security=True";

        /// <summary>
        /// Objet de factory.
        /// </summary>
        private DbProviderFactory df;

        /// <summary>
        /// Objet de connexion.
        /// </summary>
        private DbConnection cn;

        /// <summary>
        /// Création de commande de dp.
        /// </summary>
        private DbCommand cmdCommand;
        #endregion
        public ClientDAO()
        {
            // Objet du factory provider et Objet de connexion.
            this.df = DbProviderFactories.GetFactory(this.dp);
            this.cn = this.df.CreateConnection();

            try
            {
                // Ouvrir la connection avec la base de données.
                this.cn.ConnectionString = this.cnStr;
                this.cn.Open();

                // Création de commande.
                this.cmdCommand = this.df.CreateCommand();
                this.cmdCommand.Connection = this.cn;
            }
            catch (SqlException e)
            {
                // Attrapper les cas ou il n'y a pas de connexion.
                Console.WriteLine("Erreur de connexion, exception: " + e.StackTrace.ToString());
            }
        }
        #region Accesseurs et Mutateurs
        /// <summary>
        /// Gets or sets String dp.
        /// </summary>
        protected string Dp
        {
            get { return this.dp; }
            set { this.dp = value; }
        }

        /// <summary>
        /// Gets or sets String CnStr (de connexion).
        /// </summary>
        protected string CnStr
        {
            get { return this.cnStr; }
            set { this.cnStr = value; }
        }

        /// <summary>
        /// Gets or sets the Database ProviderFactory.
        /// </summary>
        protected DbProviderFactory Df
        {
            get { return this.df; }
            set { this.df = value; }
        }

        /// <summary>
        /// Gets or sets the Database Connection.
        /// </summary>
        protected DbConnection Cn
        {
            get { return this.cn; }
            set { this.cn = value; }
        }

        /// <summary>
        /// Gets or sets DbCommand cmdCommand.
        /// </summary>
        //protected DbCommand CmdCommand
        //{
        //    get { return this.cmdCommand; }
        //    set { this.cmdCommand = value; }
        //}
        #endregion
        public int sauvegardeClient(ClientVO clientvo)
        {
            

            //Requête SQL qui insère tout l'information reçu en paramètre.
                
            cmdCommand.CommandText = "Insert Into tblClient (Nom) Values('" + clientvo.NomClient + "');";
            using (DbDataReader dr = cmdCommand.ExecuteReader()) ;

            //Retrouver le numeroClient
            int idTrouve=0;
            cmdCommand.CommandText = "SELECT TOP 1 * FROM tblClient ORDER BY idClient DESC";
            using (DbDataReader dr = cmdCommand.ExecuteReader())
            {
                // Lecture de tous les résultats.
                while (dr.Read())
                {
                    idTrouve = int.Parse(dr["idClient"].ToString());
                }
            }
            return idTrouve ;       
        }
        
    }
}
