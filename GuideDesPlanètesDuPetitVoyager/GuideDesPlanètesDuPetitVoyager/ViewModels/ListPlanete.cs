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


        private bool AlreadyExiste = false;

    

        private Planete _planete;
        private ObservableCollection<Planete> _univers;  // liste des planètes.

        private ObservableCollection<Planete> Lp; // Liste de planete apres recherche.

    //    private List<Planete> ajoutPlanete { get; set; }

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
        
     

     

        public ListPlanete()
        {
            Univers = PlaneteMaker.AllPlaneteEntiteToPlanete(PlaneteDAO.GetAllPlanete());
            

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


        #endregion

        #region Add/Edit/delete

        private void OnAddAction(object o)
        {
            EventClick.GetClick().Handler += CloseAddView;

            add = new Fajout();
            add.Name = "Ajout";
            add.ShowDialog();

            
             foreach(Planete p in Univers.ToList())
             {
                
                     if ( add.ViewModelAjout.Planete.Nom.Equals(p.Nom))
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
            { //il ne faut pas que l'ajout se face quand on click sur cancel
                if (add.ViewModelAjout.CLickOnCancel == false)
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
            if (edit.ViewModelEdit.CLickOnCancel == false)
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
           Univers.Remove(Planete);
            NotifyPropertyChanged("Univers");
           
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

        private void OnTextSearch (object o)
        {
            
        }

        private void OnSearchAction(object o)
        {
            List<Planete> Lp = new List<Planete>();
          /*  foreach (Planete p in Univers)
                if (p.Nom.Equals(/*Nom de la zone de recup du nom*))
                {
                    Lp.Add(p);
                    Univers = Lp;         
              }*/
        }


       
        


        private bool CanChangeTextSearch(object o)
        {
            return true;
        }

        private bool CanSearch(object o) {
            if (Lp.Count() == 0)
            {
                Info bd = new Info("Aucune planète ne correspond à votre recherche."); //creer une fenetre info 
                bd.ShowDialog();
                return false;
            }
            else
                return true;
        }
        #endregion

    }

}



