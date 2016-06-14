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
        private FEdit edit { get; set; }
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
        
        public ObservableCollection<Planete> Lp { get; set; } //liste des planêtes rechercher

        private string connstr = GuideDesPlanètesDuPetitVoyager.Utility.GetConnectionString();


        public ListPlanete()
        {
            SqlConnection conn = new SqlConnection(connstr);
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

        private void CloseBd(object sender , EventArgs e)
        {
            bd.Close();
            EventClick.GetClick().Handler -= CloseBd;
        }

        #endregion

        #region Add/Edit/delete

        private void OnAddAction(object o)
        {
            EventClick.GetClick().Handler += CloseAddView;

            add = new Fajout();
            add.Name = "Ajout";
            add.ShowDialog();
            AlreadyExiste = false;

            //     if (Univers.Where(add.ViewModelAjout.Planete.Nom))
            //        AlreadyExiste = true;

       //     AlreadyExiste = (from Planete p in Univers where add.ViewModelAjout.Planete.Nom.Equals(p.Nom) select );
                
          //requete link a refaire   

            if (add.ViewModelAjout.CLickOnAdd == true)
            {
                foreach (Planete p in Univers)
             {

                    if (add.ViewModelAjout.Planete.Nom.ToLower().Equals(p.Nom.ToLower()))
                    {
                        AlreadyExiste = true;
                    }
            }

            if(AlreadyExiste == true)
            {
                Info info = new Info("La planète fait déjà parti de l'univers et n'as donc pas été ajouté");
                info.ShowDialog();
            }
            else
            {
                    SqlConnection conn = new SqlConnection(connstr);
                    // creation de la sql commande qui modifie l'element de la planete
                    SqlCommand cmdNewplanete = new SqlCommand("UniversDATABase.uspNewPlanete", conn);
                    cmdNewplanete.CommandType = CommandType.StoredProcedure;
                    //ajout Nom
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteNom", SqlDbType.NVarChar, 50));
                    cmdNewplanete.Parameters[@"PlaneteNom"].Value = add.ViewModelAjout.Planete.Nom;
                    //ajout Volume
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteVolume", SqlDbType.NVarChar, 20));
                    cmdNewplanete.Parameters[@"PlaneteVolume"].Value = add.ViewModelAjout.Planete.Volume;
                    //ajout Masse
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteMasse", SqlDbType.NVarChar, 20));
                    cmdNewplanete.Parameters[@"PlaneteMasse"].Value = add.ViewModelAjout.Planete.Masse;
                    //ajout anneaux
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteAnneaux", SqlDbType.NVarChar, 20));
                    cmdNewplanete.Parameters[@"PlaneteAnneaux"].Value = add.ViewModelAjout.Planete.Anneaux;
                    //ajoutdecouverte
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteDecouverte", SqlDbType.NVarChar, 15));
                    cmdNewplanete.Parameters[@"PlaneteDecouverte"].Value = add.ViewModelAjout.Planete.AnnéeDecouverte;
                    //ajout Nb satellite
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteNBSat", SqlDbType.NVarChar, 3));
                    cmdNewplanete.Parameters[@"PlaneteNBSat"].Value = add.ViewModelAjout.Planete.NbreSatellite;
                    //ajout PeriodeRevo
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlanetePeriodeRevo", SqlDbType.NVarChar,10 ));
                    cmdNewplanete.Parameters[@"PlanetePeriodeRevo"].Value = add.ViewModelAjout.Planete.PeriodeRevo;
                    //ajout PathIm
                    cmdNewplanete.Parameters.Add(new SqlParameter("@PlanetePathIm", SqlDbType.NVarChar, 300));
                    cmdNewplanete.Parameters[@"PlanetePathIm"].Value = add.ViewModelAjout.Planete.PlanIm;

                    //Parametre de sorti
  
                    cmdNewplanete.Parameters["@PlaneteNom"].Direction = ParameterDirection.Output;


                    try
                    {
                        conn.Open();
                        cmdNewplanete.ExecuteNonQuery();

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                 // Univers.Add(add.ViewModelAjout.Planete);
                    NotifyPropertyChanged("Univers");
            }
            }


        }

        private void OnEditCommand(object o) 
        {
            EventClick.GetClick().Handler += CloseEditView;

            edit = new FEdit(Planete);
            edit.Name = "Edit";
            edit.ShowDialog();
            if (edit.ViewModelEdit.CLickOnAdd == true)
            {
                NotifyPropertyChanged("Planete");
                foreach (Planete p in Univers.ToList())
                {
                    if (edit.ViewModelEdit.Planete.Nom.Equals(p.Nom))
                    {

                        Univers.Remove(p);
                        Univers.Add(edit.ViewModelEdit.Planete);
                        NotifyPropertyChanged("Univers");
                    }
                }
            }
        }

       

        private void OnDeleteCommand(object obj)
        {
            EventClick.GetClick().Handler += CloseBd;
            bd = new BoiteDeDialogue("supprimer cette planete ?");
            bd.ShowDialog();
            if (bd.ViewModelInfo._valid == true)
            {
                Univers.Remove(Planete);
                NotifyPropertyChanged("Univers");
            }
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
            string[] part = new string[8];
            System.IO.StreamReader ReadForImport = new System.IO.StreamReader(@"C:\Users\jmddu_000\Documents\LeGuideDesPlan-tes\GuideDesPlanètesDuPetitVoyager\liste_planete.txt");
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
                
                Univers.Add(PlaneteImporte);
                
                 
                /*
                //version base de donné sql
                SqlConnection conn = new SqlConnection(connstr);
                // creation de la sql commande qui modifie l'element de la planete
                SqlCommand cmdNewplanete = new SqlCommand("UniversDATABase.uspNewPlanete", conn);
                cmdNewplanete.CommandType = CommandType.StoredProcedure;
                //ajout Nom
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteNom", SqlDbType.NVarChar, 50));
                cmdNewplanete.Parameters[@"PlaneteNom"].Value = part[0];
                //ajout Volume
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteVolume", SqlDbType.NVarChar, 20));
                cmdNewplanete.Parameters[@"PlaneteVolume"].Value = part[1];
                //ajout Masse
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteMasse", SqlDbType.NVarChar, 20));
                cmdNewplanete.Parameters[@"PlaneteMasse"].Value = part[2];
                //ajout anneaux
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteAnneaux", SqlDbType.NVarChar, 20));
                cmdNewplanete.Parameters[@"PlaneteAnneaux"].Value = part[3];
                //ajoutdecouverte
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteDecouverte", SqlDbType.NVarChar, 15));
                cmdNewplanete.Parameters[@"PlaneteDecouverte"].Value = part[4];
                //ajout Nb satellite
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlaneteNBSat", SqlDbType.NVarChar, 3));
                cmdNewplanete.Parameters[@"PlaneteNBSat"].Value = part[5];
                //ajout PeriodeRevo
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlanetePeriodeRevo", SqlDbType.NVarChar, 10));
                cmdNewplanete.Parameters[@"PlanetePeriodeRevo"].Value = part[6];
                //ajout PathIm
                cmdNewplanete.Parameters.Add(new SqlParameter("@PlanetePathIm", SqlDbType.NVarChar, 300));
                cmdNewplanete.Parameters[@"PlanetePathIm"].Value = part[7];

                //Parametre de sorti

                cmdNewplanete.Parameters["@PlaneteNom"].Direction = ParameterDirection.Output;


                try
                {
                    conn.Open();
                    cmdNewplanete.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }*/

            }
            ReadForImport.Close();
            
        }
        private bool CanImport(object o)
        {
            return true;
        } // return true


        #endregion
        #region Export
        private void ExportAction(object o)
        {
            System.IO.StreamWriter WriteForExport = new System.IO.StreamWriter(@"C:\Users\jmddu_000\Desktop\Liste_Planetes.txt");
            WriteForExport.WriteLine("NOM|VOLUME|MASSE|ANNEAUX|DECOUVERTE|SATELLITES|REVOLUTION|IMAGE");
            foreach (Planete p in Univers)
                WriteForExport.WriteLine(p.Resume());
            WriteForExport.Close();

            // informer l'uilisateur de la creation du ficher 
            
            Info IWrite = new Info("Le ficher d'exportation a été créer et placer sur votre bureau");
            IWrite.ShowDialog();

        }

        private bool CanExport(object o)
        {
            return true;
        }// return true

        #endregion
        #endregion
    }

}



