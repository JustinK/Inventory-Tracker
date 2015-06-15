using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public class InventoryRepository:IInventoryRepository
    {
        private InventoryContext _ctx;

        public InventoryRepository(InventoryContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Category> GetCategories()
        {
            return _ctx.Categories;
        }

        public IQueryable<Item> GetItems()
        {
            return _ctx.Items;
        }

        public IQueryable<InventoryItem> GetInventoryItems()
        {
            return _ctx.InventoryItems;
        }
        public InventoryItem GetInventoryItemById(int inventoryItemId)
        {
            return _ctx.InventoryItems.SingleOrDefault(d => d.Id == inventoryItemId);
            
        }

        public IQueryable<Location> GetLocations()
        {
            return _ctx.Locations;
        }

        public IQueryable<Status> GetStatuses()
        {
            return _ctx.Status;
        }

        public IQueryable<Tracking> GetTrackings()
        {
            return _ctx.Trackings;
        }

        public IQueryable<Tracking> GetTrackingsByInventoryItem(int inventoryItemId)
        {
            return _ctx.Trackings.Where(p => p.InventoryItemId == inventoryItemId);
        }

        public IQueryable<Item> GetItemsByCategory(int categoryId)
        {
            return _ctx.Items.Where(p => p.CategoryId == categoryId);
        }

        public IQueryable<InventoryItem> GetInventoryItemsByLocation(int locationId)
        {
            return _ctx.InventoryItems.Where(p => p.LocationId == locationId);
        }

        public IQueryable<InventoryItem> GetInventoryItemsByStatus(int statusId)
        {

            //Todo
            return _ctx.InventoryItems;
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddCategory(Category newCategory)
        {
            try
            {
                _ctx.Categories.Add(newCategory);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddItem(Item newItem)
        {
            try
            {
                _ctx.Items.Add(newItem);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddInventoryItem(InventoryItem newInventoryItem)
        {
            try
            {
                _ctx.InventoryItems.Add(newInventoryItem);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddLocation(Location newLocation)
        {
            try
            {
                _ctx.Locations.Add(newLocation);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddStatus(Status newStatus)
        {
            try
            {
                _ctx.Status.Add(newStatus);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddTracking(Tracking newTracking)
        {
            try
            {
                _ctx.Trackings.Add(newTracking);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _ctx.Categories.AddOrUpdate(category);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                _ctx.Items.AddOrUpdate(item);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _ctx.InventoryItems.AddOrUpdate(inventoryItem);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateLocation(Location location)
        {
            try
            {
                _ctx.Locations.AddOrUpdate(location);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateStatus(Status status)
        {
            try
            {
                _ctx.Status.AddOrUpdate(status);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool UpdateTracking(Tracking tracking)
        {
            try
            {
                _ctx.Trackings.AddOrUpdate(tracking);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }


        public bool RemoveInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _ctx.InventoryItems.Remove(inventoryItem);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool RemoveTracking(Tracking tracking)
        {
            try
            {
                _ctx.Trackings.Remove(tracking);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }
    }
}