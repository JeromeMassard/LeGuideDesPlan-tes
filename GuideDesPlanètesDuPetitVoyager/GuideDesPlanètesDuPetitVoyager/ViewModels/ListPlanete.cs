using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UniverseBuilder.Entites;
using GuideDesPlanètesDuPetitVoyager.Maker;
using UniverseBuilder;
using System.Data;
using GuideDesPlanètesDuPetitVoyager.Event;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using System.Data.Common;
using ClassLibrary1.Extension;
using GuideDesPlanètesDuPetitVoyager;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    public class ListPlanete : NotifyPropertyChangedBase
    {
        #region DelegateCommande
        public DelegateCommande OnAddCommande { get; set; }
        public DelegateCommande OnEditCommande { get; set; }
        public DelegateCommande OnDeleteCommande { get; set; }

        public DelegateCommande OnImportCommande { get; set; }
        public DelegateCommande OnExportCommande { get; set; }
        public DelegateCommande ClickOnSearch { get; set; }

        #endregion

        private Fajout add { get; set; }
        private Fajout edit { get; set; }
        private BoiteDeDialogue bd { get; set; }


        private bool AlreadyExiste = false;
        private string _textrecherche;
        public string TextRecherche
        {
            get { return _textrecherche; }
            set
            {
                _textrecherche = value;
                NotifyPropertyChanged("TextRecherche");
            }
        }

        private Planete _planete;
        private ObservableCollection<Planete> _univers;  // liste des planètes.



        public Planete Planete
        {
            get { return _planete; }
            set
            {
                _planete = value;
                NotifyPropertyChanged("Planete");
                NotifyPropertyChanged("ListPlanete");
                OnEditCommande.RaiseCanExecuteChanged();
                OnDeleteCommande.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<Planete> Univers
        {
            get { return _univers; }
            set { _univers = value; }
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jmddu_000\Documents\LeGuideDesPlan-tes\GuideDesPlanètesDuPetitVoyager\UniverseBuilder\UniversDATABase.mdf;Integrated Security=True";



        public ListPlanete()
        {

            Univers = PlaneteMaker.AllPlaneteEntiteToPlanete(PlaneteDAO.GetAllPlanete());

            TextRecherche = "Voyager...";
            OnAddCommande = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnEditCommande = new DelegateCommande(OnEditCommand, CanEditCommand);
            OnDeleteCommande = new DelegateCommande(OnDeleteCommand, CanDeleteCommand);


            OnImportCommande = new DelegateCommande(ImportAction, CanImport);
            OnExportCommande = new DelegateCommande(ExportAction, CanExport);

            ClickOnSearch = new DelegateCommande(OnSearchAction, CanSearch);

        }


        public void GotFocusAction()
        {
            TextRecherche = "";
        }


        #region close
        private void CloseAddView(object sender, EventArgs e)
        {
            add.Close();
            EventClick.GetClick().Handler -= CloseAddView;
        }


        private void CloseEditView(object sender, EventArgs e)
        {
            edit.Close();
            EventClick.GetClick().Handler -= CloseEditView;
        }

        private void CloseBd(object sender, EventArgs e)
        {
            bd.Close();
            EventClick.GetClick().Handler -= CloseBd;
        }

        #endregion

        #region Add/Edit/delete

        private void OnAddAction(object o)
        {
            EventClick.GetClick().Handler += CloseAddView;
            Planete PlaneteAjout = new Planete();
            add = new Fajout(PlaneteAjout);
            add.Name = "Ajout";
            add.ShowDialog();
            AlreadyExiste = false;


            if (add.ViewModelAjout.CLickOnAdd == true)
            {
                foreach (Planete p in Univers)
                {

                    if (add.ViewModelAjout.Planete.Nom.ToLower().Equals(p.Nom.ToLower()))
                    {
                        AlreadyExiste = true;
                    }
                }

                if (AlreadyExiste == true)
                {
                    Info info = new Info("La planète fait déjà parti de l'univers et n'as donc pas été ajouté");
                    info.ShowDialog();
                }
                else
                {

                    SqlConnection conn = new SqlConnection(connectionString);

                    conn.Open();
                    Planete planeteAdd = add.ViewModelAjout.Planete;
                    string SQLcmdAdd = "INSERT INTO [UniversDATABase].[Planete] VALUES (@PNom,@PVol,@PMas,@PAnn,@PDec,@PSat,@PRev,@PIma);";

                    var command = new SqlCommand(SQLcmdAdd, conn);
                    command.Parameters.AddWithValue("@PNom", planeteAdd.Nom);
                    command.Parameters.AddWithValue("@PVol", planeteAdd.Volume);
                    command.Parameters.AddWithValue("@PMas", planeteAdd.Masse);
                    command.Parameters.AddWithValue("@PAnn", planeteAdd.Anneaux);
                    command.Parameters.AddWithValue("@PDec", planeteAdd.AnnéeDecouverte);
                    command.Parameters.AddWithValue("@PSat", planeteAdd.NbreSatellite);
                    command.Parameters.AddWithValue("@PRev", planeteAdd.PeriodeRevo);
                    command.Parameters.AddWithValue("@PIma", planeteAdd.PlanIm);
                    command.ExecuteReader();
                    conn.Close();

                    NotifyPropertyChanged("Univers");

                }
                Refresh();
            }


        }

        private void OnEditCommand(object o)
        {
            EventClick.GetClick().Handler += CloseEditView;

            edit = new Fajout(Planete); // Factorisation de code. on utilise la même fenetre que pour l'ajout de planete 
            edit.ViewModelAjout.AddOrModify = "Valider"; // changement du contenu bouton 
            edit.Name = "Edit";
            edit.ShowDialog();
            if (edit.ViewModelAjout.CLickOnAdd == true)
            {
                NotifyPropertyChanged("Planete");
                Planete modifAApliquer = edit.ViewModelAjout.Planete;


                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string SQLcmdAdd = "UPDATE [UniversDATABase].[Planete] SET PlaneteVolume = @PVol,PlaneteMasse = @PMas,PlaneteAnneaux = @PAnn, PlaneteDecouverte = @PDec, PlaneteNBSat = @PSat, PlanetePeriodeRevo = @PRev, PlanetePathIm = @PIma WHERE PlaneteNom = @PNom";

                var command = new SqlCommand(SQLcmdAdd, conn);
                command.Parameters.AddWithValue("@PNom", modifAApliquer.Nom);
                command.Parameters.AddWithValue("@PVol", modifAApliquer.Volume);
                command.Parameters.AddWithValue("@PMas", modifAApliquer.Masse);
                command.Parameters.AddWithValue("@PAnn", modifAApliquer.Anneaux);
                command.Parameters.AddWithValue("@PDec", modifAApliquer.AnnéeDecouverte);
                command.Parameters.AddWithValue("@PSat", modifAApliquer.NbreSatellite);
                command.Parameters.AddWithValue("@PRev", modifAApliquer.PeriodeRevo);
                command.Parameters.AddWithValue("@PIma", modifAApliquer.PlanIm);

                command.ExecuteReader();
                conn.Close();

                NotifyPropertyChanged("Planete");
                NotifyPropertyChanged("Univers");


            }
            Refresh();
        }



        private void OnDeleteCommand(object obj)
        {
            EventClick.GetClick().Handler += CloseBd;
            bd = new BoiteDeDialogue("supprimer cette planete ?");
            bd.ShowDialog();
            if (bd.ViewModelInfo._valid == true)
            {
                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                string SQLcmdAdd = "DELETE FROM [UniversDATABase].[Planete] WHERE PlaneteNom = @PNom"; //test
                var command = new SqlCommand(SQLcmdAdd, conn);
                command.Parameters.AddWithValue("@PNom", Planete.Nom);
                command.ExecuteReader();
                conn.Close();
                NotifyPropertyChanged("Univers");
            }
            Refresh();
        }

        #region Can
        private bool CanExecuteAdd(object o)
        {
            return true;
        }

        private bool CanEditCommand(Object o)
        {
            return Planete != null;
        }

        private bool CanDeleteCommand(object obj)
        {
            return Planete != null;
        }
        #endregion
        #endregion

        #region Search
        private void OnSearchAction(object o)
        {
            foreach (Planete p in Univers)
            {
                if (TextRecherche.ToLower().Equals(p.Nom.ToLower()))
                {
                    Planete = p;
                }

            }
            if (Planete == null)
            {
                Info bd = new Info("Aucune planète ne correspond à votre recherche."); //creer une fenetre info 
                bd.ShowDialog();
            }
            TextRecherche = "Voyager...";
        }


        private bool CanSearch(object o)
        {
            return true;
        }
        #endregion

        #region Import/Export

        #region Import

        private void ImportAction(object o)
        {
            Planete PlaneteImporte;
            string line;
            string chemin = "";
            string[] part = new string[8];


            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Selectionner un fichier";
            op.Filter = "Fichier texte(.txt)|*.txt|" +
              "*.*|*.*";
            if (op.ShowDialog() == true)
            {
                chemin = op.FileName;
            }
            if (chemin != "")
            {

                System.IO.StreamReader ReadForImport = new System.IO.StreamReader(chemin);
                line = ReadForImport.ReadLine(); // eleve la ligne des infos colonnes
                while ((line = ReadForImport.ReadLine()) != null)
                {

                    PlaneteImporte = new Planete();
                    part = line.Split('|');

                    PlaneteImporte.Nom = part[0];
                    PlaneteImporte.Volume = part[1];
                    PlaneteImporte.Masse = part[2];
                    PlaneteImporte.Anneaux = part[3];
                    PlaneteImporte.AnnéeDecouverte = part[4];
                    PlaneteImporte.NbreSatellite = part[5];
                    PlaneteImporte.PeriodeRevo = part[6];
                    PlaneteImporte.PlanIm = part[7];

                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();

                    string SQLcmdAdd = "INSERT INTO [UniversDATABase].[Planete] VALUES (@PNom,@PVol,@PMas,@PAnn,@PDec,@PSat,@PRev,@PIma);";

                    var command = new SqlCommand(SQLcmdAdd, conn);
                    command.Parameters.AddWithValue("@PNom", PlaneteImporte.Nom);
                    command.Parameters.AddWithValue("@PVol", PlaneteImporte.Volume);
                    command.Parameters.AddWithValue("@PMas", PlaneteImporte.Masse);
                    command.Parameters.AddWithValue("@PAnn", PlaneteImporte.Anneaux);
                    command.Parameters.AddWithValue("@PDec", PlaneteImporte.AnnéeDecouverte);
                    command.Parameters.AddWithValue("@PSat", PlaneteImporte.NbreSatellite);
                    command.Parameters.AddWithValue("@PRev", PlaneteImporte.PeriodeRevo);
                    command.Parameters.AddWithValue("@PIma", PlaneteImporte.PlanIm);
                    command.ExecuteReader();
                    conn.Close();

                    NotifyPropertyChanged("Univers");

                }
                ReadForImport.Close();
            }
        }
        private bool CanImport(object o)
        {
            return true;
        } // return true


        #endregion
        #region Export
        private void ExportAction(object o)
        {

            string cheminDossier = "";
            System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                cheminDossier = new DirectoryInfo(fbd.SelectedPath).Name;
            }
            if (cheminDossier != "")// eviter les chemins null
            {
                System.IO.StreamWriter WriteForExport = new System.IO.StreamWriter(cheminDossier);
                WriteForExport.WriteLine("NOM|VOLUME|MASSE|ANNEAUX|DECOUVERTE|SATELLITES|REVOLUTION|IMAGE");
                foreach (Planete p in Univers)
                    WriteForExport.WriteLine(p.Resume());
                WriteForExport.Close();

                // informer l'uilisateur de la creation du ficher 

                Info IWrite = new Info("Le fichier a bien été exporté.");
                IWrite.ShowDialog();
            }
            else
            {
                Info IWrite = new Info("Le fichier n'a pas été exporté car le chemin n'a pas été correctement renseigné.");
                IWrite.ShowDialog();
            }


        }

        private bool CanExport(object o)
        {
            return true;
        }// return true

        #endregion
        #endregion

        //test refresh
        public void Refresh()
        {
            Univers.Clear();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jmddu_000\Documents\LeGuideDesPlan-tes\GuideDesPlanètesDuPetitVoyager\UniverseBuilder\UniversDATABase.mdf;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [UniversDATABase].[Planete]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var planeteE = new Planete();
                            planeteE.Nom = reader["PlaneteNom"].ToString();
                            planeteE.Volume = reader["PlaneteVolume"].ToString();
                            planeteE.Masse = reader["PlaneteMasse"].ToString();
                            planeteE.Anneaux = reader["PlaneteAnneaux"].ToString();
                            planeteE.AnnéeDecouverte = reader["PlaneteDecouverte"].ToString();
                            planeteE.NbreSatellite = reader["PlaneteNBSat"].ToString();
                            planeteE.PeriodeRevo = reader["PlanetePeriodeRevo"].ToString();
                            planeteE.PlanIm = reader["PlanetePathIm"].ToString();

                            Univers.Add(planeteE);
                        }
                    }
                }
            }

        }
    }
}



