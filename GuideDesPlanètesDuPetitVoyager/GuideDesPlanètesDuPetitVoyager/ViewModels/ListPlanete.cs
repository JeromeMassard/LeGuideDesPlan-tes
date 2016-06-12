using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UniverseBuilder.Entites;
using GuideDesPlanètesDuPetitVoyager.Maker;
using UniverseBuilder;
using GuideDesPlanètesDuPetitVoyager.Event;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    public class ListPlanete : NotifyPropertyChangedBase
    {

        public DelegateCommande OnAddCommande { get; set; }
        public DelegateCommande OnEditCommande { get; set; }
        public DelegateCommande OnDeleteCommande { get; set; }

        public DelegateCommande ClickOnTextSearch { get; set; }
        public DelegateCommande ClickOnSearch { get; set; }


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

     

        public ListPlanete()
        {
            Univers = PlaneteMaker.AllPlaneteEntiteToPlanete(PlaneteDAO.GetAllPlanete());

            TextRecherche = "Voyager...";
            OnAddCommande = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnEditCommande = new DelegateCommande(OnEditCommand, CanEditCommand);
            OnDeleteCommande = new DelegateCommande(OnDeleteCommand, CanDeleteCommand);

           ClickOnTextSearch = new DelegateCommande(OnTextSearch, CanChangeTextSearch);
           ClickOnSearch = new DelegateCommande(OnSearchAction, CanSearch);
           
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

                    if (add.ViewModelAjout.Planete.Nom.Equals(p.Nom))
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
                    Univers.Add(add.ViewModelAjout.Planete);
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

        #region Search

        public void OnTextSearch (object o)
        {
            TextRecherche = "";
        }

        private void OnSearchAction(object o)
        { 
            foreach (Planete p in Univers)
            {
                if (TextRecherche.Equals(p.Nom))
                {
                    Planete = p;
                }
                
            }
            if (Planete == null) 
            {
                Info bd = new Info("Aucune planète ne correspond à votre recherche."); //creer une fenetre info 
                bd.ShowDialog();
            }
        }


       
        

        private bool CanChangeTextSearch(object o)
        {
            return true;
        }

        private bool CanSearch(object o)
        {
            
                return true;
        }
        #endregion
        
    }

}



