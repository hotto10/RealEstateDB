using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using RealEstate.WebUI.Models;
using RealEstateDB.Data.Facades;

namespace RealEstate.WebUI.Pages
{
    public class RentalPropertyBase : ComponentBase
    {
        #region Properties
        public bool IsLoading { get; set; }
        public bool ShowDataEntryForm { get; set; }
        public bool ShowDeleteConfirmation { get; set; }
        public bool PopUpHelper { get; set; }
        public int PageSize { get; set; }
        public string DataEntryTitle { get; set; }
        public List<RentalPropertyViewModel>? Properties { get; set; }
        public IList<RentalPropertyViewModel>? SelectedRow { get; set; }
        
        public RadzenDataGrid<RentalPropertyViewModel>? dataGrid;
        public RentalPropertyViewModel? ActiveModel { get; set; }


        #endregion


        #region Methods

        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }
        protected async Task GetData()
        {
            //By setting to true it is going to enable the loading setting on the grid, line 19-statehaschanged changes the page to go get data
            this.IsLoading = true;
            StateHasChanged();

            await Task.Run(() => LoadData());
            
            this.IsLoading = false;
            StateHasChanged();

        }
        void LoadData()
        {
            this.Properties = new();
            

            PageSize = 15;
            PopUpHelper = true;
            var results = RentalPropertyDataFacade.GetAllRentalProperties<RentalPropertyViewModel>();
            if (results != null && results.Count > 0)
                this.Properties = results;
        }
        public async void OnFormSubmit(RentalPropertyViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            ShowDataEntryForm = false;

            // Save Record
            RentalPropertyDataFacade.SaveRecord(model);
            // Reload All Records
            LoadData();


            this.IsLoading = false;
            StateHasChanged();
        }
        public void NewRentalPropertyClicked()
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "New Rental Property Address";
            ActiveModel = new();
            ShowDataEntryForm = true;

            this.IsLoading = false;
            StateHasChanged();
        }
        public void EditRentalPropertyClicked(RentalPropertyViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "Updating Rental Property Address";
            ActiveModel = model;
            ShowDataEntryForm = true;

            this.IsLoading = false;
            StateHasChanged();
        }
        public void DeleteRentalPropertyClicked(RentalPropertyViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "Delete Rental Property Address";
            ActiveModel = model;
            ShowDataEntryForm = true;
            ShowDeleteConfirmation = true;

            this.IsLoading = false;
            StateHasChanged();
        }
        public void CancelRentalPropertyClicked()
        {
            this.IsLoading = true;
            StateHasChanged();
            ActiveModel = null;
            ShowDataEntryForm = false;
            LoadData();

            this.IsLoading = false;
            StateHasChanged();
        }
        public void DeleteConfirmationClicked()
        {
            this.IsLoading = true;
            StateHasChanged();
            
            ShowDeleteConfirmation = false;
            ShowDataEntryForm = false;
            RentalPropertyDataFacade.DeleteRecord(ActiveModel);
            LoadData();

            this.IsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
