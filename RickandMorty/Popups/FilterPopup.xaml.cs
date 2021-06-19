using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using RickandMorty.Models;
using RickandMorty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickandMorty.Popups
{
    public partial class FilterPopup : PopupPage
    {
        FilterVM filterVM;

        public FilterPopup()
        {
            InitializeComponent();

            filterVM = new FilterVM();
        }


        #region Events

        private void Status_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            filterVM.Status = ((RadioButton)sender).Content.ToString().ToLower();
        }

        private void Gender_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            filterVM.Gender = ((RadioButton)sender).Content.ToString().ToLower();
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            if (PopupNavigation.Instance.PopupStack.Contains(this))
                await PopupNavigation.Instance.RemovePageAsync(this);

            MessagingCenter.Send<FilterVM>(filterVM, "FadeOut");
        }

        #endregion
    }
}