using Rg.Plugins.Popup.Extensions;
using RickandMorty.Models;
using RickandMorty.Services;
using RickandMorty.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickandMorty.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersList : ContentPage
    {
        CharactersVM charactersVM;

        public CharactersList()
        {
            InitializeComponent();

            charactersVM = ((CharactersVM)BindingContext);
        }

        public void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                if (charactersVM.ChractarsList?.Count < charactersVM.response.Info.Count && charactersVM.ChractarsList?.Count == (e.ItemIndex + 1))
                {
                    charactersVM.GetData(charactersVM.response.Info.Next);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }

        private void Filter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new Popups.FilterPopup());
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new CharacterDetails()
            {
                BindingContext = new CharacterDetailVM(((Character)e.Item).Id)
            });
        }

        private void Refresh_List(object sender, EventArgs e)
        {
            charactersVM.GetData(Utility.BaseUrl, true);
            listView.IsRefreshing = false;
        }
    }
}