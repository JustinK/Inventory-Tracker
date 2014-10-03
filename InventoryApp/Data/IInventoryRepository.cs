using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public interface IInventoryRepository
    {
        IQueryable<Category> GetCategories();
        IQueryable<Item> GetItems();
        IQueryable<InventoryItem> GetInventoryItems();
        IQueryable<Location> GetLocations();
        IQueryable<Status> GetStatuses();
        IQueryable<Tracking> GetTrackings();
        InventoryItem GetInventoryItemById(int inventoryItemId);

        IQueryable<Tracking> GetTrackingsByInventoryItem(int inventoryItemId);
        IQueryable<Item> GetItemsByCategory(int categoryId);
        IQueryable<InventoryItem> GetInventoryItemsByLocation(int locationId);
        IQueryable<InventoryItem> GetInventoryItemsByStatus(int statusId);


        bool Save();

        bool AddCategory(Category newCategory);
        bool AddItem(Item newItem);
        bool AddInventoryItem(InventoryItem newInventoryItem);
        bool AddLocation(Location newLocation);
        bool AddStatus(Status newStatus);
        bool AddTracking(Tracking newTracking);

        bool UpdateCategory(Category category);
        bool UpdateItem(Item item);
        bool UpdateInventoryItem(InventoryItem inventoryItem);
        bool UpdateLocation(Location location);
        bool UpdateStatus(Status status);
        bool UpdateTracking(Tracking tracking);

        
        bool RemoveInventoryItem(InventoryItem inventoryItem);
        bool RemoveTracking(Tracking tracking);



    }
}