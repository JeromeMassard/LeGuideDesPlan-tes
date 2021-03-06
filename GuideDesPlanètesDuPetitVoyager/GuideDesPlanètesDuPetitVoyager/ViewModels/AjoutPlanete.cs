﻿using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideDesPlanètesDuPetitVoyager.Event;
using Microsoft.Win32;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    public class AjoutPlanete : NotifyPropertyChangedBase
    {
        public DelegateCommande OnAddNew { get; set; }
        public DelegateCommande OnCancel { get; set; }
        public DelegateCommande LoadCommand { get; set; }

        public string AddOrModify { get; set; }   // Changement du contenu du bouton de validation

        public bool CLickOnAdd = false;

        private Planete _planete;
        public Planete Planete
        {
            get { return _planete; }
            set
            {
                _planete = value;
                NotifyPropertyChanged("Planete");
                NotifyPropertyChanged("ListPlanete");
                OnAddNew.RaiseCanExecuteChanged();
            }
        }


        public AjoutPlanete(Planete _planete)
        {
            AddOrModify = "Ajouter";
            OnAddNew = new DelegateCommande(OnAddAction, CanAdd); //Commande du bouton Ajouter et Modifier
            OnCancel = new DelegateCommande(OnCancelCommand, CanCancel); //Commande du bouton Annuler
            LoadCommand = new DelegateCommande(OnLoadCommand, CanLoadCommand); //Commande du bouton parcourir 
            Planete = _planete;
           
        }

        #region Add

        private void OnAddAction(object obj)
        {
            CLickOnAdd = true;
            if (Planete.Nom != null)
                EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
            else
            { 
                    Info iadd = new Info("Tous les champs doivent être completé pour ajouter une nouvelle planete");
                    iadd.ShowDialog();
            }
        }
        private bool CanAdd(object obj)
        {
            return true;
        }
        #endregion


        #region Cancel
        private void OnCancelCommand(object obj)
        {
            CLickOnAdd = false; // cas ou on clic sur cancel après l'affichage de iadd
             EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }
        private bool CanCancel(object obj)
        {
            return true;
        }
        #endregion
 
              
        #region load

        private void OnLoadCommand(object o)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selectionner une image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Planete.PlanIm = op.FileName;
                NotifyPropertyChanged("Planete");
                }
        }

        private bool CanLoadCommand(object o)
        {
            return true;
        }


        #endregion

    }
}
