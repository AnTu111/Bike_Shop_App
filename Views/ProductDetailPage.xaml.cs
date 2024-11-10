using BikeShopApp.Models;
using BikeShopApp.Services;
using System;

namespace BikeShopApp.Views;

public partial class ProductDetailPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly Product _product;

    public ProductDetailPage(DatabaseService databaseService, Product product)
    {
        InitializeComponent();
        _databaseService = databaseService;
        _product = product;
        LoadProductDetails();
    }

    private void LoadProductDetails()
    {
        ProductNameLabel.Text = _product.Name;
        ProductDescriptionLabel.Text = _product.Description;
        ProductIngredientsLabel.Text = $"Bicycle handlebar: {_product.Type}";
        ProductPriceLabel.Text = $"Value: {_product.Price:C}";
        ProductImage.Source = ImageSource.FromFile(_product.ImagePath);
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {

        MenuCategory category = await _databaseService.GetCategoryByIdAsync(_product.BikeCategoryId); 

        await Navigation.PushAsync(new AddProductPage(_databaseService, category, _product));
    }


    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var confirm = await DisplayAlert("Confirmation", "Are you sure you want to delete this?", "Yes", "No");
        if (confirm)
        {
            await _databaseService.DeleteProductAsync(_product);
            await Navigation.PopAsync();
        }
    }
}
