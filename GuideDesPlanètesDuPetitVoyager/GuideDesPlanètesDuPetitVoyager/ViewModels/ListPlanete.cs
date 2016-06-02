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


        private bool _visibility;



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
        
        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                NotifyPropertyChanged("Visibility");
            }
        }

        public int CloseAddView { get; private set; }

        public ListPlanete()
        {
            Univers = PlaneteMaker.AllPlaneteEntiteToPlanete(PlaneteDAO.GetAllPlanete());
            

            OnAddCommande = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnEditCommande = new DelegateCommande(OnEditCommand, CanEditCommand);
            OnDeleteCommande = new DelegateCommande(OnDeleteCommand, CanDeleteCommand);

            ClickOnTextSearch = new DelegateCommande(OnTextSearch, CanChangeTextSearch);
            ClickOnSearch = new DelegateCommande(OnSearchAction, CanSearch);
           
        }


        private void CloseView(object sender, EventArgs e)
        {
            add.Close();

            EventClick.GetClick().Handler -= CloseView;
        }

        #region Add/Edit/delete

        private void OnAddAction(object o)
        {
            EventClick.GetClick().Handler += CloseView;

            add = new Fajout();
            add.Name = "Ajout";
            add.ShowDialog();

            Univers.Add(add.ViewModelAjout.Planete);
            NotifyPropertyChanged("Univers");
     

            /* foreach(Planete p in Univers.ToList())
             {

                     if (_planete.Equals(p))
                     {
                         Info infoAdd = new Info("La planète fait déjà parti de l'univers et n'as donc pas été ajouté");
                         infoAdd.ShowDialog();
                     }
                     else
                     {
                         Univers.Add(_planete);
                     }
             }
             */
        }

        private void OnEditCommand(object o) 
        {
            FEdit edit = new FEdit(Planete);
            edit.Name = "Edit";
            edit.ShowDialog();
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
            return this.Planete != null;
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



