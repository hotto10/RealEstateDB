using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using RealEstate.WebUI.Models;
using RealEstateDB.Data.Facades;

namespace RealEstate.WebUI.Pages
{
    public class TenantBase: ComponentBase
    {
        #region Properties
        public bool IsLoading { get; set; }
        public bool ShowDataEntryForm { get; set; }
        public bool ShowDeleteConfirmation { get; set; }
        public bool PopUpHelper { get; set; }
        public int PageSize { get; set; }
        public string DataEntryTitle { get; set; }
        public List<TenantViewModel>? Tenants { get; set; }
        public IList<TenantViewModel>? SelectedRow { get; set; }

        public RadzenDataGrid<TenantViewModel>? dataGrid;
        public TenantViewModel? ActiveModel { get; set; }


        #endregion


        #region Methods
        public async void OnFormSubmit(TenantViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            ShowDataEntryForm = false;
            
            // Save Record
            ApplicantDataFacade.SaveRecord(model);
            // Reload All Records
            LoadData();


            this.IsLoading = false;
            StateHasChanged();
        }
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
            Tenants = new();
            PopUpHelper = true;
            //Tenants.Add(new TenantViewModel() { FirstName="Heather"});
            PageSize = 15;
            this.Tenants = ApplicantDataFacade.ReadAllRecord<TenantViewModel>();
        }
        public void NewRentalPropertyClicked()
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "New Tenant";
            ActiveModel = new();
            ShowDataEntryForm = true;

            this.IsLoading = false;
            StateHasChanged();
        }
        public void EditRentalPropertyClicked(TenantViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "Updating Tenant";
            ActiveModel = model;
            ShowDataEntryForm = true;

            this.IsLoading = false;
            StateHasChanged();
        }
        public void DeleteRentalPropertyClicked(TenantViewModel model)
        {
            this.IsLoading = true;
            StateHasChanged();
            this.DataEntryTitle = "Delete Tenant";
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
            ApplicantDataFacade.DeleteRecord(ActiveModel);
            LoadData();

            this.IsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
